using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Inventories
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMouvementController : ControllerBase
    {
        private readonly InventoryMouvementService _inventoryMouvementService;
        private readonly ILogger<InventoryMouvementController> _logger;
        public InventoryMouvementController(InventoryMouvementService inventoryMouvementService, ILogger<InventoryMouvementController> logger)
        {
            _inventoryMouvementService = inventoryMouvementService;
            _logger = logger;
        }

        // Get paged inventoryMouvement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryMouvementDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var inventoryMouvement = await _inventoryMouvementService.GetPagedInventoryMouvementAsync(pageNumber, pageSize);
            return Ok(inventoryMouvement);
        }

        // Get inventoryMouvement by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryMouvementDTO>> GetInventoryMouvement(int id)
        {
            var inventoryMouvement = await _inventoryMouvementService.GetInventoryMouvementByIdAsync(id);
            if (inventoryMouvement == null)
            {
                return NotFound();
            }
            return Ok(inventoryMouvement);
        }

        // Create a new inventoryMouvement
        [HttpPost]
        public async Task<ActionResult<InventoryMouvementDTO>> CreateInventoryMouvement(InventoryMouvementDTO inventoryMouvementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var inventoryMouvement = new InventoryMouvement
                {
                    ProductId = inventoryMouvementDto.ProductId,
                    LocationId = inventoryMouvementDto.LocationId,
                    MouvementType = inventoryMouvementDto.MouvementType,
                    Quantity = inventoryMouvementDto.Quantity,
                    MouvementDate = inventoryMouvementDto.MouvementDate
                };

                await _inventoryMouvementService.CreateInventoryMouvementAsync(inventoryMouvement);

                var responseDto = new InventoryMouvementDTO
                {
                    ProductId = inventoryMouvement.ProductId,
                    LocationId = inventoryMouvement.LocationId,
                    MouvementType = inventoryMouvement.MouvementType,
                    Quantity = inventoryMouvement.Quantity,
                    MouvementDate = inventoryMouvement.MouvementDate
                };

                return CreatedAtAction(nameof(GetInventoryMouvement), new { id = inventoryMouvement.InventoryMouvementId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update a inventoryMouvement
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventoryMouvement(int id, InventoryMouvementDTO inventoryMouvementDto)
        {
            if (id != inventoryMouvementDto.InventoryMouvementId)
            {
                return BadRequest("Inventory Mouvement ID mismatch.");
            }

            var existingInventoryMouvement = await _inventoryMouvementService.GetInventoryMouvementByIdAsync(id);
            if (existingInventoryMouvement == null)
            {
                return NotFound("Inventory Mouvement not found.");
            }

            var inventoryMouvement = new InventoryMouvement
            {
                InventoryMouvementId = id,
                ProductId = inventoryMouvementDto.ProductId,
                LocationId = inventoryMouvementDto.LocationId,
                MouvementType = inventoryMouvementDto.MouvementType,
                Quantity = inventoryMouvementDto.Quantity,
                MouvementDate = inventoryMouvementDto.MouvementDate
            };

            await _inventoryMouvementService.UpdateInventoryMouvementAsync(inventoryMouvement);
            return NoContent();
        }

        // Delete a inventoryMouvement
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryMouvement(int id)
        {
            await _inventoryMouvementService.DeleteInventoryMouvementAsync(id);
            return NoContent();
        }
    }
}
