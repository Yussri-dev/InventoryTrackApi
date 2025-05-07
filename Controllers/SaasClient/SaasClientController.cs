using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.SaasClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaasClientController : ControllerBase
    {
        private readonly SaasClientService _saasClientService;
        private readonly ILogger<SaasClientController> _logger;
        private readonly IMapper _mapper;

        public SaasClientController(SaasClientService saasClientService,
            ILogger<SaasClientController> logger, IMapper mapper)
        {
            _saasClientService = saasClientService ?? throw new ArgumentNullException(nameof(saasClientService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get paged categories
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<SaasClientDTO>>> GetPagedSaasClient(int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _saasClientService.GetPagedSaass(pageNumber, pageSize);
            return Ok(categories);
        }

        //// Get product by Name
        [HttpGet("Name/{name}")]
        //[Authorize]
        public async Task<ActionResult<SaasClientDTO>> GetSaasClientByName([FromRoute] string name)
        {
            try
            {
                var unit = await _saasClientService.GetSaasClientByNameAsync(name);
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
        public async Task<ActionResult<SaasClientDTO>> GetSaasClient([FromRoute] int id)
        {
            var line = await _saasClientService.GetSaasClientByIdAsync(id);
            if (line == null)
            {
                return NotFound();
            }
            return Ok(line);
        }

        // Create a new line
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<SaasClientDTO>> CreateSaasClient(SaasClientDTO lineDto)
        {

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for create SaasClient");
            }
            try
            {
                var saasClient = _mapper.Map<Models.SaasClient>(lineDto);
                await _saasClientService.CreateSaasClientAsync(saasClient);

                var responseDto = _mapper.Map<SaasClientDTO>(saasClient);
                return CreatedAtAction(nameof(GetSaasClient), new { id = saasClient.SaasClientId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Creating SaasClient: {ex.Message}");
                return Problem(
                    title: "An error occurred while creating the SaasClient.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        // Update a line
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateSaasClient([FromRoute] int id, SaasClientDTO saasDto)
        {
            _logger.LogInformation($"UpdateSaasClient request received for ID: {id}");

            if (id != saasDto.SaasClientId)
            {
                _logger.LogWarning($"SaasClient ID mismatch: Route ID {id} does not match DTO ID {saasDto.SaasClientId}");
                return BadRequest("SaasClient ID mismatch.");
            }

            try
            {
                var existingSaasClient = await _saasClientService.GetSaasClientByIdAsync(id);
                if (existingSaasClient == null)
                {
                    _logger.LogWarning($"SaasClient with ID {id} not found");
                    return NotFound("SaasClient not found.");
                }

                _logger.LogInformation($"Updating SaasClient with ID {id}");
                var line = _mapper.Map<Models.SaasClient>(saasDto);
                await _saasClientService.UpdateSaasClientAsync(line);

                _logger.LogInformation($"SaasClient with ID {id} successfully updated");
                return Ok(line);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating SaasClient with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }


        // Delete a line
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteSaasClient([FromRoute] int id)
        {
            await _saasClientService.DeleteSaasClientAsync(id);
            return NoContent();
        }


    }
}
