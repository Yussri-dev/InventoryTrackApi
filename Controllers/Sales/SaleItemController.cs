using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq.Expressions;

namespace InventoryTrackApi.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleItemController : ControllerBase
    {
        private readonly SaleItemService _saleItemService;
        private readonly ILogger<SaleItemController> _logger;
        public SaleItemController(
            SaleItemService saleItemService,
            ILogger<SaleItemController> logger)
        {
            _saleItemService = saleItemService;
            _logger = logger;
        }

        // Get paged saleItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleItemDTO>>> GetPagedSaleItems(int pageNumber = 1, int pageSize = 10)
        {
            var saleItems = await _saleItemService.GetSaleItemsWithProductAsync(pageNumber, pageSize);
            return Ok(saleItems);
        }


        // Get paged sale items by date range
        //[HttpGet("pagedSaleitemsByDate")]
        //public async Task<ActionResult<IEnumerable<SaleItemDTO>>> GetPagedSaleItemsByDateAsync(
        //    DateTime startDate, DateTime endDate, int pageNumber = 1, int pageSize = 10)
        //{
        //    var saleItems = await _saleItemService.GetPagedSaleItemsByDateAsync(startDate, endDate, pageNumber, pageSize);
        //    return Ok(saleItems);
        //}
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

        //// Get product by ID
        [HttpGet("ByBarCode/{id}")]
        public async Task<ActionResult<SaleItemDTO>> GetProductByBarCode(int id)
        {
            try
            {
                var product = await _saleItemService.GetPagedSaleItemsByIdAsync(id);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product by name");
                return StatusCode(500, "Internal server error");
            }
        }


        // Create a new saleItem
        [HttpPost]
        public async Task<ActionResult<SaleItemDTO>> CreateSaleItem(SaleItemDTO saleItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var saleItem = new SaleItem
                {
                    SaleId = saleItemDto.SaleId,
                    ProductId = saleItemDto.ProductId,
                    Quantity = saleItemDto.Quantity,
                    Price = saleItemDto.Price,
                    Discount = saleItemDto.Discount,
                    TaxAmount = saleItemDto.TaxAmount,
                    Total = saleItemDto.Total,
                    ProfitMarge = saleItemDto.ProfitMarge,
                    PurchasePrice = saleItemDto.PurchasePrice
                };
                await _saleItemService.CreateSaleItemAsync(saleItem);

                var responseDto = new SaleItemDTO
                {
                    SaleId = saleItem.SaleId,
                    ProductId = saleItem.ProductId,
                    Quantity = saleItem.Quantity,
                    Price = saleItem.Price,
                    Discount = saleItem.Discount,
                    TaxAmount = saleItem.TaxAmount,
                    Total = saleItem.Total,
                    ProfitMarge = saleItem.ProfitMarge,
                    PurchasePrice = saleItem.PurchasePrice
                };
                return CreatedAtAction(nameof(GetSaleItem), new { id = saleItem.SaleItemId }, saleItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Sale Item");
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        // Update a saleItem
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSaleItem(int id, SaleItemDTO saleItemDto)
        {
            if (id != saleItemDto.SaleItemId)
            {
                return BadRequest("Sale item ID mismatch.");
            }

            var existingSaleItem = await _saleItemService.GetSaleItemByIdAsync(id);
            if (existingSaleItem == null)
            {
                return NotFound("Sale Item not found.");
            }

            var saleItem = new SaleItem
            {
                SaleItemId = id,
                SaleId = saleItemDto.SaleId,
                Quantity = saleItemDto.Quantity,
                Price = saleItemDto.Price,
                Discount = saleItemDto.Discount,
                TaxAmount = saleItemDto.TaxAmount,
                Total = saleItemDto.Total,
                ProfitMarge = saleItemDto.ProfitMarge,
                PurchasePrice = saleItemDto.PurchasePrice
            };

            await _saleItemService.UpdateSaleItemAsync(saleItem);
            return NoContent();
        }

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



    }
}
