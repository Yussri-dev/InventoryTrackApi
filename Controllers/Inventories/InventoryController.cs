using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Inventories
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;
        private readonly ILogger<InventoryController> _logger;
        public InventoryController(InventoryService inventoryService, ILogger<InventoryController> logger)
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }

        // Get paged inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var inventories = await _inventoryService.GetPagedInventoryAsync(pageNumber, pageSize);
            return Ok(inventories);
        }

        // Get inventory by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDTO>> GetInventory(int id)
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }

        // Create a new inventory
        [HttpPost]
        public async Task<ActionResult<InventoryDTO>> CreateInventory(InventoryDTO inventoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var inventory = new Inventory
                {
                    LocationId = inventoryDto.LocationId,
                    ProductId = inventoryDto.ProductId,
                    Quantity = inventoryDto.Quantity,
                    CreatedBy = inventoryDto.CreatedBy,
                    DateCreated = inventoryDto.DateCreated
                };

                await _inventoryService.CreateInventoryAsync(inventory);

                var responseDto = new InventoryDTO
                {
                    LocationId = inventory.LocationId,
                    ProductId = inventory.ProductId,
                    Quantity = inventory.Quantity,
                    ModifiedBy = inventory.ModifiedBy,
                    DateModified = inventory.DateModified
                };

                return CreatedAtAction(nameof(GetInventory), new { id = inventory.InventoryId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating inventory");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update a inventory
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(int id, InventoryDTO inventoryDto)
        {
            if (id != inventoryDto.InventoryId)
            {
                return BadRequest("Inventory ID mismatch.");
            }

            var existingEmployee = await _inventoryService.GetInventoryByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound("Inventory not found.");
            }

            var inventory = new Inventory
            {
                InventoryId = id,
                LocationId = inventoryDto.LocationId,
                ProductId = inventoryDto.ProductId,
                Quantity = inventoryDto.Quantity,
                ModifiedBy = inventoryDto.ModifiedBy,
                DateModified = inventoryDto.DateModified
            };

            await _inventoryService.UpdateInventoryAsync(inventory);
            return NoContent();
        }

        // Delete a inventory
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            await _inventoryService.DeleteInventoryAsync(id);
            return NoContent();
        }
    }
}
