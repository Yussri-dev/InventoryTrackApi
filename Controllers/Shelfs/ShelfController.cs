using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Shelfs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly ShelfService _shelfService;
        private readonly ILogger<ShelfController> _logger;

        public ShelfController(ShelfService shelfService, ILogger<ShelfController> logger)
        {
            _shelfService = shelfService ?? throw new ArgumentNullException(nameof(shelfService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelfDTO>>> GetPagedShelfs(int pageNumber, int pageSize)
        {
            var shelfs = await _shelfService.GetPagedShelfs(pageNumber, pageSize);
            return Ok(shelfs);
        }

        //Get Shelf by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ShelfDTO>> GetShelf(int id)
        {
            var shelf = await _shelfService.GetShelfByIdAsync(id);
            if (shelf == null)
            {
                return NotFound();
            }
            return Ok(shelf);
        }

        //Create a new Shelf
        [HttpPost]
        public async Task<ActionResult<ShelfDTO>> CreateProduct(ShelfDTO shelfDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var shelf = new Shelf
                {
                    Name = shelfDto.Name,
                };

                await _shelfService.CreateShelfAsync(shelf);

                var responseDto = new ShelfDTO
                {
                    Name = shelf.Name
                };

                return CreatedAtAction(nameof(GetShelf), new { id = shelf.ShelfId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update a product
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShelf(int id, ShelfDTO shelfDto)
        {
            if (id != shelfDto.ShelfId)
            {
                return BadRequest();
            }

            var shelf = new Shelf
            {
                Name = shelfDto.Name
            };

            await _shelfService.UpdateShelfAsync(shelf);
            return NoContent();
        }
         */

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShelf(int id, ShelfDTO shelfDto)
        {
            if (id != shelfDto.ShelfId)
            {
                return BadRequest("Shelf ID mismatch.");
            }

            var existingShelf = await _shelfService.GetShelfByIdAsync(id);
            if (existingShelf == null)
            {
                return NotFound("Shelf not found.");
            }

            var shelf = new Shelf
            {
                ShelfId = id,
                Name = shelfDto.Name
            };
            // Call the service to update the shelf
            await _shelfService.UpdateShelfAsync(shelf);

            return NoContent();
        }
        // Delete a product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShelf(int id)
        {
            await _shelfService.DeleteShelfAsync(id);
            return NoContent();
        }

        //// Get product by Name
        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<ShelfDTO>> GetShelfByName(string name)
        {
            try
            {
                var shelf = await _shelfService.GetShelfByNameAsync(name);
                return Ok(shelf);
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
    }
}
