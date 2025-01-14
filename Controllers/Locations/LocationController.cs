using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Locations
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;
        private readonly ILogger<LocationController> _logger;
        public LocationController(LocationService locationService, ILogger<LocationController> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        // Get paged locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var locations = await _locationService.GetPagedLocationAsync(pageNumber, pageSize);
            return Ok(locations);
        }

        // Get location by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> GetLocation(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // Create a new location
        [HttpPost]
        public async Task<ActionResult<LocationDTO>> CreateLocation(LocationDTO locationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var location = new Location
                {
                    Name = locationDto.Name,
                };

                await _locationService.CreateLocationAsync(location);

                var responseDto = new LocationDTO
                {
                    Name = location.Name
                };

                return CreatedAtAction(nameof(GetLocation), new { id = location.LocationId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating location");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update a location
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, LocationDTO locationDto)
        {
            if (id != locationDto.LocationId)
            {
                return BadRequest("Location ID mismatch.");
            }

            var existingLocation = await _locationService.GetLocationByIdAsync(id);
            if (existingLocation == null)
            {
                return NotFound("Location not found.");
            }

            var location = new Location
            {
                LocationId = id,
                Name = locationDto.Name
            };

            await _locationService.UpdateLocationAsync(location);
            return NoContent();
        }

        // Delete a location
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocationASync(id);
            return NoContent();
        }
    }
}
