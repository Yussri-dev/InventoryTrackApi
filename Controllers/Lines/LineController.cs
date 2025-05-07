using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Lines
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LineController : ControllerBase
    {
        private readonly LineService _lineService;
        private readonly ILogger<LineController> _logger;
        private readonly IMapper _mapper;

        public LineController(LineService lineService, 
            ILogger<LineController> logger, IMapper mapper)
        {
            _lineService = lineService ?? throw new ArgumentNullException(nameof(lineService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get paged categories
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<LineDTO>>> GetPagedLines(int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _lineService.GetPagedLines(pageNumber, pageSize);
            return Ok(categories);
        }

        //// Get product by Name
        [HttpGet("Name/{name}")]
        //[Authorize]
        public async Task<ActionResult<LineDTO>> GetLineByName([FromRoute]string name)
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
        //[Authorize]
        public async Task<ActionResult<LineDTO>> GetLine([FromRoute]int id)
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
        //[Authorize]
        public async Task<ActionResult<LineDTO>> CreateLine(LineDTO lineDto)
        {

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for create Line");
            }
            try
            {
                var line = _mapper.Map<Line>(lineDto);
                await _lineService.CreateLineAsync(line);

                var responseDto = _mapper.Map<LineDTO>(line);
                return CreatedAtAction(nameof(GetLine), new { id = line.LineId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Creating Line: {ex.Message}");
                return Problem(
                    title: "An error occurred while creating the Line.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        // Update a line
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateLine([FromRoute]int id, LineDTO lineDto)
        {
            _logger.LogInformation($"UpdateLine request received for ID: {id}");

            if (id != lineDto.LineId)
            {
                _logger.LogWarning($"Line ID mismatch: Route ID {id} does not match DTO ID {lineDto.LineId}");
                return BadRequest("Line ID mismatch.");
            }

            try
            {
                var existingLine = await _lineService.GetLineByIdAsync(id);
                if (existingLine == null)
                {
                    _logger.LogWarning($"Line with ID {id} not found");
                    return NotFound("Line not found.");
                }

                _logger.LogInformation($"Updating Line with ID {id}");
                var line = _mapper.Map<Line>(lineDto);
                await _lineService.UpdateLineAsync(line);

                _logger.LogInformation($"Line with ID {id} successfully updated");
                return Ok(line);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Line with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }


        // Delete a line
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteLine([FromRoute] int id)
        {
            await _lineService.DeleteLineAsync(id);
            return NoContent();
        }
    }
}
