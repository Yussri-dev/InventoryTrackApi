using InventoryTrackApi.Controllers.Returns;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace InventoryTrackApi.Controllers.Returns
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnItemController : ControllerBase
    {
        private readonly ReturnItemService _returnItemService;
        private readonly ILogger<ReturnItemController> _logger;
        public ReturnItemController(
            ReturnItemService ReturnItemService,
            ILogger<ReturnItemController> logger)
        {
            _returnItemService = ReturnItemService;
            _logger = logger;
        }

        // Get paged ReturnItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnItemDTO>>> GetPagedReturnItems(int pageNumber = 1, int pageSize = 10)
        {
            var ReturnItems = await _returnItemService.GetReturnItemsWithProductAsync(pageNumber, pageSize);
            return Ok(ReturnItems);
        }

        [HttpGet("pagedReturnItemsByDate")]
        public async Task<ActionResult<IEnumerable<ReturnItemDTO>>> GetPagedReturnItemsByDateAsync(
        [FromQuery] string startDate, [FromQuery] string endDate, int pageNumber = 1, int pageSize = 10)
        {
            if (!DateTime.TryParseExact(startDate, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedStartDate) ||
                !DateTime.TryParseExact(endDate, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedEndDate))
            {
                return BadRequest("Invalid date format. Please use MM-dd-yyyy.");
            }

            var ReturnItems = await _returnItemService.GetPagedReturnItemsByDateAsync(parsedStartDate, parsedEndDate, pageNumber, pageSize);
            return Ok(ReturnItems);
        }

        // Get ReturnItem by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnItemDTO>> GetReturnItem(int id)
        {
            var ReturnItem = await _returnItemService.GetReturnItemByIdAsync(id);
            if (ReturnItem == null)
            {
                return NotFound();
            }
            return Ok(ReturnItem);
        }

        // Create a new ReturnItem
        [HttpPost]
        public async Task<ActionResult<ReturnItemDTO>> CreateReturnItem(ReturnItemDTO ReturnItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var ReturnItem = new ReturnItem
                {
                    ReturnId = ReturnItemDto.ReturnId,
                    ProductId = ReturnItemDto.ProductId,
                    Quantity = ReturnItemDto.Quantity,
                    RefundAmount = ReturnItemDto.RefundAmount,
                    DateCreated = ReturnItemDto.DateCreated,
                };
                await _returnItemService.CreateReturnItemAsync(ReturnItem);

                var responseDto = new ReturnItemDTO
                {
                    ReturnId = ReturnItem.ReturnId,
                    ProductId = ReturnItem.ProductId,
                    Quantity = ReturnItem.Quantity,
                    RefundAmount = ReturnItem.RefundAmount,
                    DateCreated = ReturnItem.DateCreated,
                };
                return CreatedAtAction(nameof(GetReturnItem), new { id = ReturnItem.ReturnItemId }, ReturnItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Return Item");
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        // Update a ReturnItem
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReturnItem(int id, ReturnItemDTO ReturnItemDto)
        {
            if (id != ReturnItemDto.ReturnItemId)
            {
                return BadRequest("Return item ID mismatch.");
            }

            var existingReturnItem = await _returnItemService.GetReturnItemByIdAsync(id);
            if (existingReturnItem == null)
            {
                return NotFound("Return Item not found.");
            }

            var ReturnItem = new ReturnItem
            {
                ReturnItemId = id,
                ReturnId = ReturnItemDto.ReturnId,
                ProductId = ReturnItemDto.ProductId,
                Quantity = ReturnItemDto.Quantity,
                RefundAmount = ReturnItemDto.RefundAmount
            };

            await _returnItemService.UpdateReturnItemAsync(ReturnItem);
            return NoContent();
        }

        // Delete a ReturnItem
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturnItem(int id)
        {
            await _returnItemService.DeleteReturnItemAsync(id);
            return NoContent();
        }
    }
}
