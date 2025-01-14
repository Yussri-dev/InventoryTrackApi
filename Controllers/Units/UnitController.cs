using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Units
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly UnitService _unitService;
        private readonly ILogger<UnitController> _logger;

        public UnitController(UnitService unitService, ILogger<UnitController> logger)
        {
            _unitService = unitService ?? throw new ArgumentNullException(nameof(unitService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Get paged units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var units = await _unitService.GetPagedUnitsAsync(pageNumber, pageSize);
            return Ok(units);
        }

        //// Get product by Name
        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<UnitDTO>> GetUnitByName(string name)
        {
            try
            {
                var unit = await _unitService.GetUnitByNameAsync(name);
                return Ok(unit);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving unit by name");
                return StatusCode(500, "Internal server error");
            }
        }

        // Get unit by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitDTO>> GetUnit(int id)
        {
            var unit = await _unitService.GetUnitByIdAsync(id);
            if (unit == null)
            {
                return NotFound(new { message = $"Unit with ID {id} not found." });
            }
            return Ok(unit);
        }
        /*
         [HttpPost]
        public async Task<ActionResult<UnitDTO>> CreateUnit(UnitDTO unitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var unit = new Unit
                {
                    Name = unitDto.Name,
                };

                await _unitService.CreateUnitAsync(unit);

                var responseDto = new UnitDTO
                {
                    Name = unit.Name
                };

                return CreatedAtAction(nameof(GetUnit), new { id = unit.UnitId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

         */
        // Create a new unit
        [HttpPost]
        public async Task<ActionResult<UnitDTO>> CreateUnit(UnitDTO unitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unit = new Unit
            {
                Name = unitDto.Name,
            };

            await _unitService.CreateUnitAsync(unit);

            var responseDto = new UnitDTO
            {
                Name = unit.Name
            };

            return CreatedAtAction(nameof(GetUnit), new { id = unit.UnitId }, responseDto);
        }
        // Update a unit
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUnit(int id, UnitDTO unitDto)
        {
            if (id != unitDto.UnitId)
            {
                return BadRequest("Unit ID mismatch.");
            }

            var existingUnit = await _unitService.GetUnitByIdAsync(id);
            if (existingUnit == null)
            {
                return NotFound("Unit not found.");
            }

            var unit = new Unit
            {
                UnitId = id,
                Name = unitDto.Name,
            };

            await _unitService.UpdateUnitAsync(unit);
            return NoContent();
        }

        // Delete a unit
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            await _unitService.DeleteUnitAsync(id);
            return NoContent();
        }
    }
}
