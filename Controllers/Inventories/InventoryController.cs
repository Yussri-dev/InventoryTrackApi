using AutoMapper;
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
        private readonly IMapper _mapper; 
        public InventoryController(InventoryService inventoryService, ILogger<InventoryController> logger, IMapper mapper)
        {
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
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
                _logger.LogInformation($"Create Inventory request for Inventory: {inventoryDto}");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for creating Inventory");
                }
                try
                {
                    var inventory = _mapper.Map<Inventory>(inventoryDto);
                    await _inventoryService.CreateInventoryAsync(inventory);

                    var responseDto = _mapper.Map<CustomerDTO>(inventory);
                    return CreatedAtAction(nameof(GetInventory), new { id = inventory.InventoryId }, responseDto);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error creating Inventory : {ex.Message}");
                    return Problem(
                        title: "An error occured while creating the inventory",
                        detail: ex.Message,
                        statusCode: StatusCodes.Status500InternalServerError
                        );
                    throw;
                }
            /*
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
            */
        }

        // Update a inventory
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(int id, InventoryDTO inventoryDto)
        {
            _logger.LogInformation($"Update inventory request received for Id : {id}");
            if (id != inventoryDto.InventoryId)
            {
                _logger.LogWarning($"Inventory ID mismatch : Route Id {id} does not match DTO ID {inventoryDto.InventoryId}");
                return BadRequest("Customer ID mismatch");
            }
            try
            {
                var existingInventory = await _inventoryService.GetInventoryByIdAsync(id);
                if (existingInventory == null)
                {
                    _logger.LogWarning($"Inventory with ID : {id} not found");
                    return NotFound("Inventory Not Found");
                }

                _logger.LogInformation($"Updating Inventory with Id {id}");
                var inventory = _mapper.Map<Inventory>(inventoryDto);
                await _inventoryService.UpdateInventoryAsync(inventory);

                _logger.LogInformation($"Inventory with ID {id} successfully updated");
                return Ok(inventory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Inventory with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
            /*
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
            */
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
