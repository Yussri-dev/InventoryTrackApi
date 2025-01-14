using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Lines
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : ControllerBase
    {
        private readonly LineService _lineService;
        private readonly ILogger<LineController> _logger;

        public LineController(LineService lineService, ILogger<LineController> logger)
        {
            _lineService = lineService;
            _logger = logger;
        }

        // Get paged categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _lineService.GetPagedLines(pageNumber, pageSize);
            return Ok(categories);
        }

        //// Get product by Name
        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<LineDTO>> GetLineByName(string name)
        {
            try
            {
                var unit = await _lineService.GetLineByNameAsync(name);
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

        // Get line by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<LineDTO>> GetLine(int id)
        {
            var line = await _lineService.GetLineByIdAsync(id);
            if (line == null)
            {
                return NotFound();
            }
            return Ok(line);
        }

        // Create a new line
        [HttpPost]
        public async Task<ActionResult<LineDTO>> CreateLine(LineDTO lineDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var line = new Line
                {
                    Name = lineDto.Name,
                };

                await _lineService.CreateLineAsync(line);

                var responseDto = new LineDTO
                {
                    Name = line.Name
                };

                return CreatedAtAction(nameof(GetLine), new { id = line.LineId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating line");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update a line
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLine(int id, LineDTO lineDto)
        {
            if (id != lineDto.LineId)
            {
                return BadRequest("Line ID mismatch.");
            }

            var existingEmployee = await _lineService.GetLineByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound("Line not found.");
            }

            var line = new Line
            {
                LineId = id,
                Name = lineDto.Name
            };

            await _lineService.UpdateLineAsync(line);
            return NoContent();
        }

        // Delete a line
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLine(int id)
        {
            await _lineService.DeleteLineAsync(id);
            return NoContent();
        }
    }
}
