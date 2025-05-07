using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Locations
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;
        private readonly ILogger<LocationController> _logger;
        private readonly IMapper _mapper;


        public LocationController(LocationService locationService, ILogger<LocationController> logger, IMapper mapper)
        {
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //// Get Location by Name
        [HttpGet("Name/{name}")]
        //[Authorize]
        public async Task<ActionResult<LineDTO>> GetLocationByName([FromRoute] string name)
        {
            try
            {
                var unit = await _locationService.GetLocationByNameAsync(name);
                return Ok(unit);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving Location by name");
                return StatusCode(500, "Internal server error");
            }
        }


        // Get paged locations
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            _logger.LogInformation($"Get All Locations");

            var locations = await _locationService.GetPagedLocationAsync(pageNumber, pageSize);
            return Ok(locations);
        }

        // Get location by ID
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<LocationDTO>> GetLocation([FromRoute]int id)
        {
            _logger.LogInformation($"Get Location By Id : {id}");
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
            {
                _logger.LogWarning($"Location with ID {id} not found");
                return NotFound();
            }
            return Ok(location);
        }

        // Create a new location
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<LocationDTO>> CreateLocation(LocationDTO locationDto)
        {
            _logger.LogInformation($"CreateLocation request for Location: {locationDto}");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Location");
            }
            try
            {
                var location = _mapper.Map<Location>(locationDto);
                await _locationService.CreateLocationAsync(location);

                var responseDto = _mapper.Map<LocationDTO>(location);
                return CreatedAtAction(nameof(GetLocation), new { id = location.LocationId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating Location : {ex.Message}");
                return Problem(
                    title: "An error occured while creating the location",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                    );
                throw;
            }
        }

        // Update a location
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateLocation([FromRoute] int id, LocationDTO locationDto)
        {
            _logger.LogInformation($"UpdateLocation request received for Id : {id}");
            if (id != locationDto.LocationId)
            {
                _logger.LogWarning($"Location ID mismatch : Route Id {id} does not match DTO ID {locationDto.LocationId}");
                return BadRequest("Location ID mismatch");
            }
            try
            {
                var existingLocation = await _locationService.GetLocationByIdAsync(id);
                if (existingLocation == null)
                {
                    _logger.LogWarning($"Location with ID : {id} not fount");
                    return NotFound("Location Not Found");
                }

                _logger.LogInformation($"Updating location with Id {id}");
                var location = _mapper.Map<Location>(locationDto);
                await _locationService.UpdateLocationAsync(location);

                _logger.LogInformation($"location with ID {id} successfully updated");
                return Ok(location);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Location with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }

        // Delete a location
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteLocation([FromRoute]int id)
        {
            await _locationService.DeleteLocationASync(id);
            return NoContent();
        }
    }
}
