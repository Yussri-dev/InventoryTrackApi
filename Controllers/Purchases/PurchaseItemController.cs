using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Purchases
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseItemController : ControllerBase
    {
        private readonly PurchaseItemService _purchaseItemService;
        private readonly ILogger<PurchaseItemController> _logger;

        public PurchaseItemController(PurchaseItemService purchaseItemService, ILogger<PurchaseItemController> logger)
        {
            _purchaseItemService = purchaseItemService;
            _logger = logger;
        }

        // Get paged purchaseItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseItemDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var purchaseItems = await _purchaseItemService.GetPagedPurchaseItemsAsync(pageNumber, pageSize);
            return Ok(purchaseItems);
        }

        // Get purchaseItem by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseItemDTO>> GetPurchaseItem(int id)
        {
            var purchaseItem = await _purchaseItemService.GetPurchaseItemByIdAsync(id);
            if (purchaseItem == null)
            {
                return NotFound();
            }
            return Ok(purchaseItem);
        }

        // Create a new purchaseItem
        [HttpPost]
        public async Task<ActionResult<PurchaseItemDTO>> CreatePurchaseItem(PurchaseItemDTO purchaseItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var purchaseItem = new PurchaseItem
                {
                    PurchaseId = purchaseItemDto.PurchaseId,
                    ProductId = purchaseItemDto.ProductId,
                    Quantity = purchaseItemDto.Quantity,
                    Price = purchaseItemDto.Price,
                    Discount = purchaseItemDto.Discount,
                    TaxAmount = purchaseItemDto.TaxAmount,
                    Total = purchaseItemDto.Total
                };
                await _purchaseItemService.CreatePurchaseItemAsync(purchaseItem);
                var respondDto = new PurchaseItemDTO
                {
                    PurchaseId = purchaseItem.PurchaseId,
                    ProductId = purchaseItem.ProductId,
                    Quantity = purchaseItem.Quantity,
                    Price = purchaseItem.Price,
                    Discount = purchaseItem.Discount,
                    TaxAmount = purchaseItem.TaxAmount,
                    Total = purchaseItem.Total
                };
                return CreatedAtAction(nameof(GetPurchaseItem), new { id = purchaseItem.PurchaseItemId }, purchaseItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Purchase Item");
                return StatusCode(500, $"Internal server error : {ex.Message}");
            }

        }

        // Update a purchaseItem
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchaseItem(int id, PurchaseItemDTO purchaseItemDto)
        {
            if (id != purchaseItemDto.PurchaseItemId)
            {
                return BadRequest("Purchase Item ID mismatch.");
            }

            var existingPurchaseItem = await _purchaseItemService.GetPurchaseItemByIdAsync(id);
            if (existingPurchaseItem == null)
            {
                return NotFound("Purchase Item not found.");
            }

            var purchaseItem = new PurchaseItem
            {
                PurchaseItemId = id,
                PurchaseId = purchaseItemDto.PurchaseId,
                ProductId = purchaseItemDto.ProductId,
                Quantity = purchaseItemDto.Quantity,
                Price = purchaseItemDto.Price,
                Discount = purchaseItemDto.Discount,
                TaxAmount = purchaseItemDto.TaxAmount,
                Total = purchaseItemDto.Total
            };

            await _purchaseItemService.UpdatePurchaseItemAsync(purchaseItem);
            return NoContent();
        }

        // Delete a purchaseItem
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseItem(int id)
        {
            await _purchaseItemService.DeletePurchaseItemAsync(id);
            return NoContent();
        }
    }
}
