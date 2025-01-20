using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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

        [HttpGet("pagedSaleitemsByDate")]
        public async Task<ActionResult<IEnumerable<SaleItemDTO>>> GetPagedSaleItemsByDateAsync(
        [FromQuery] string startDate, [FromQuery] string endDate, int pageNumber = 1, int pageSize = 10)
        {
            if (!DateTime.TryParseExact(startDate, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedStartDate) ||
                !DateTime.TryParseExact(endDate, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedEndDate))
            {
                return BadRequest("Invalid date format. Please use MM-dd-yyyy.");
            }

            var saleItems = await _saleItemService.GetPagedSaleItemsByDateAsync(parsedStartDate, parsedEndDate, pageNumber, pageSize);
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
                    Total = saleItemDto.Total
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
                    Total = saleItem.Total
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
                Total = saleItemDto.Total
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

    }
}
