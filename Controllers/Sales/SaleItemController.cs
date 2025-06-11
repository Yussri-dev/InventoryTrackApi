using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq.Expressions;

namespace InventoryTrackApi.Controllers.Sales
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class SaleItemController : ControllerBase
    {
        private readonly SaleItemService _saleItemService;
        private readonly ILogger<SaleItemController> _logger;
        private readonly IMapper _mapper;
        public SaleItemController(
            SaleItemService saleItemService,
            ILogger<SaleItemController> logger, IMapper mapper)
        {
            _saleItemService = saleItemService;
            _logger = logger;
            _mapper = mapper;
        }

        // Get paged saleItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleItemDTO>>> GetPagedSaleItems(int pageNumber = 1, int pageSize = 10)
        {
            var saleItems = await _saleItemService.GetPagedSaleItemsAsync(pageNumber, pageSize);
            return Ok(saleItems);
        }

        [HttpGet("SaleItemsDateRange")]
        public async Task<ActionResult<IEnumerable<SaleItemDTO>>> GetPagedSaleItemsByDateRangeAsync(
                    [FromQuery] string startDate, [FromQuery] string endDate)
        {
            // Parse the start date
            if (!DateTime.TryParseExact(
                    startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out var startSalesDate))
            {
                return BadRequest("Invalid start date format. Use dd/MM/yyyy.");
            }

            // Parse the end date
            if (!DateTime.TryParseExact(
                    endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out var endSalesDate))
            {
                return BadRequest("Invalid end date format. Use dd/MM/yyyy.");
            }

            // Ensure the end date is inclusive of the entire day
            endSalesDate = endSalesDate.AddDays(1).AddSeconds(-1);

            // Fetch sale items within the date range
            var saleItems = await _saleItemService.GetPagedSaleItemsByDateRangeAsync(startSalesDate, endSalesDate);

            return Ok(saleItems);
        }

        // Get saleItem by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleItemDTO>> GetSaleItem(int id)
        {
            var saleItem = await _saleItemService.GetSaleItemByIdAsync(id);
            if (saleItem == null)
            {
                return NotFound();
            }
            return Ok(saleItem);
        }

        //// Get saleItem by ID
        [HttpGet("ByBarCode/{id}")]
        public async Task<ActionResult<SaleItemDTO>> GetSaleItemByBarCode(int id)
        {
            try
            {
                var saleItem = await _saleItemService.GetPagedSaleItemsByIdAsync(id);
                return Ok(saleItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving saleItem by name");
                return StatusCode(500, "Internal server error");
            }
        }


        // Create a new saleItem
        [HttpPost]
        public async Task<ActionResult<SaleItemDTO>> CreateSaleItem(SaleItemDTO saleItemDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for Create Sale Item.");
                return ValidationProblem(ModelState);
            }
            try
            {
                var sale = _mapper.Map<SaleItem>(saleItemDto);
                await _saleItemService.CreateSaleItemAsync(sale);

                var respondDto = _mapper.Map<SaleItemDTO>(sale);
                return CreatedAtAction(nameof(GetSaleItem), new { id = sale.SaleItemId }, respondDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Sale: {Message}", ex.Message);
                return Problem(
                    title: "An error occurred while creating the purchase.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

        }

        //// Update a saleItem

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateSaleItem([FromRoute] int id, SaleItemDTO saleItemDto)
        {
            _logger.LogInformation($"Update SaleItem request received for Id : {id}");
            if (id != saleItemDto.SaleItemId)
            {
                _logger.LogWarning($"SaleItem ID mismatch : Route Id {id} does not match DTO ID {saleItemDto.SaleItemId}");
                return BadRequest("SaleItem ID mismatch");
            }
            try
            {
                var existingSaleItem = await _saleItemService.GetSaleItemByIdAsync(id);
                if (existingSaleItem == null)
                {
                    _logger.LogWarning($"SaleItem with ID : {id} not fount");
                    return NotFound("SaleItem Not Found");
                }

                _logger.LogInformation($"Updating saleItem with Id {id}");
                var saleItem = _mapper.Map<SaleItem>(saleItemDto);
                await _saleItemService.UpdateSaleItemAsync(saleItem);

                _logger.LogInformation($"saleItem with ID {id} successfully updated");
                return Ok(saleItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating SaleItem with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateSaleItem(int id, SaleItemDTO saleItemDto)
        //{
        //    if (id != saleItemDto.SaleItemId)
        //    {
        //        return BadRequest("Sale item ID mismatch.");
        //    }

        //    var existingSaleItem = await _saleItemService.GetSaleItemByIdAsync(id);
        //    if (existingSaleItem == null)
        //    {
        //        return NotFound("Sale Item not found.");
        //    }

        //    var saleItem = new SaleItem
        //    {
        //        SaleItemId = id,
        //        SaleId = saleItemDto.SaleId,
        //        Quantity = saleItemDto.Quantity,
        //        Price = saleItemDto.Price,
        //        Discount = saleItemDto.Discount,
        //        TaxAmount = saleItemDto.TaxAmount,
        //        Total = saleItemDto.Total,
        //        ProfitMarge = saleItemDto.ProfitMarge,
        //        PurchasePrice = saleItemDto.PurchasePrice
        //    };

        //    await _saleItemService.UpdateSaleItemAsync(saleItem);
        //    return NoContent();
        //}

        // Delete a saleItem
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleItem(int id)
        {
            await _saleItemService.DeleteSaleItemAsync(id);
            return NoContent();
        }

        [HttpGet("profits")]
        public async Task<ActionResult<decimal>> CalculateProfits([FromQuery] string startDate)
        {
            try
            {
                if (!DateTime.TryParseExact(
                    startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out var parsedStartDate))
                {
                    return BadRequest("Invalid date format. Use dd/MM/yyyy.");
                }

                var totalProfits = await _saleItemService.CalculateProfitsAsync(parsedStartDate);

                //Return the decimal value directly instead of JSON
                return Ok(totalProfits);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //GetCustomerSalesAsync(int customerId)
        [HttpGet("SaleItems/{id}")]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetCustomerSalesAsync(int id)
        {
            // Fetch sales within the date range
            var saleItems = await _saleItemService.GetSalesItemByIdAsync(id);

            return Ok(saleItems);
        }

    }
}
