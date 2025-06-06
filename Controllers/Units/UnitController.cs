﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public UnitController(UnitService unitService, ILogger<UnitController> logger, IMapper mapper)
        {
            _unitService = unitService ?? throw new ArgumentNullException(nameof(unitService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get paged units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var units = await _unitService.GetPagedUnitsAsync(pageNumber, pageSize);
            return Ok(units);
        }

        //// Get unit by Name
        [HttpGet("Name/{name}")]
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
        
        // Create a new unit
        [HttpPost]
        public async Task<ActionResult<UnitDTO>> CreateUnit(UnitDTO unitDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Unit");
            }
            try
            {
                var unit = _mapper.Map<Unit>(unitDto);
                await _unitService.CreateUnitAsync(unit);

                var responsDto = _mapper.Map<UnitDTO>(unitDto);
                return CreatedAtAction(nameof(GetUnit), new { id = unit }, responsDto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Creating Unit: {ex.Message}");
                return Problem(
                    title: "An error occurred while creating the unit.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        // Update a unit

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateUnit([FromRoute] int id, UnitDTO unitDto)
        {
            _logger.LogInformation($"Update Unit request received for Id : {id}");
            if (id != unitDto.UnitId)
            {
                _logger.LogWarning($"Unit ID mismatch : Route Id {id} does not match DTO ID {unitDto.UnitId}");
                return BadRequest("Unit ID mismatch");
            }
            try
            {
                var existingUnit = await _unitService.GetUnitByIdAsync(id);
                if (existingUnit == null)
                {
                    _logger.LogWarning($"Unit with ID : {id} not fount");
                    return NotFound("Unit Not Found");
                }

                _logger.LogInformation($"Updating unit with Id {id}");
                var unit = _mapper.Map<Unit>(unitDto);
                await _unitService.UpdateUnitAsync(unit);

                _logger.LogInformation($"unit with ID {id} successfully updated");
                return Ok(unit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Unit with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUnit(int id, UnitDTO unitDto)
        //{
        //    if (id != unitDto.UnitId)
        //    {
        //        return BadRequest("Unit ID mismatch.");
        //    }

        //    var existingEmployee = await _unitService.GetUnitByIdAsync(id);
        //    if (existingEmployee == null)
        //    {
        //        return NotFound("Unit not found.");
        //    }

        //    var purchase = _mapper.Map<Unit>(unitDto);
        //    await _unitService.UpdateUnitAsync(purchase);
        //    return NoContent();
        //    //if (id != unitDto.UnitId)
        //    //{
        //    //    return BadRequest("Unit ID mismatch.");
        //    //}

        //    //var existingUnit = await _unitService.GetUnitByIdAsync(id);
        //    //if (existingUnit == null)
        //    //{
        //    //    return NotFound("Unit not found.");
        //    //}

        //    //var unit = new Unit
        //    //{
        //    //    UnitId = id,
        //    //    Name = unitDto.Name,
        //    //};

        //    //await _unitService.UpdateUnitAsync(unit);
        //    //return NoContent();
        //}

        // Delete a unit
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            await _unitService.DeleteUnitAsync(id);
            return NoContent();
        }
    }
}
