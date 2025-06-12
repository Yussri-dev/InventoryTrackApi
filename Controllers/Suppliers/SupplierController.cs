using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Suppliers
{
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    //[Route("api/v{version:apiversion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierService _supplierService;
        private readonly ILogger<SupplierController> _logger;
        private readonly IMapper _mapper;

        public SupplierController(SupplierService supplierService, ILogger<SupplierController> logger,
            IMapper mapper)
        {
            _supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get paged suppliers
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var suppliers = await _supplierService.GetPagedCutomersAsync(pageNumber, pageSize);
            return Ok(suppliers);
        }

        //[HttpGet("supplierUser")]
        //[MapToApiVersion("2.0")]
        //[HttpGet]
        ////[Authorize]
        //public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetPagesSuppliersByUsers(string userId, int pageNumber = 1, int pageSize = 10)
        //{
        //    var suppliers = await _supplierService.GetPagedCutomersAsync(pageNumber, pageSize);
        //    return Ok(suppliers);
        //}

        //public IActionResult UserId()
        //{
        //    return Ok("Nouvelle fonctionnalité v2");
        //}

        // Get supplier by ID
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<SupplierDTO>> GetSupplier(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        [HttpGet("count")]
        public async Task<int> GetSupplierCount()
        {
            return await _supplierService.GetSuppliersCountAsync();
        }
        // Create a new supplier
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> CreateSupplier(SupplierDTO supplierDto)
        {
            _logger.LogInformation($"Create Supplier request for Supplier: {supplierDto}");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Supplier");
            }
            try
            {
                var supplier = _mapper.Map<Supplier>(supplierDto);
                await _supplierService.CreateSupplierAsync(supplier);

                var responseDto = _mapper.Map<SupplierDTO>(supplier);
                return CreatedAtAction(nameof(GetSupplier), new { id = supplier.SupplierId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating Supplier : {ex.Message}");
                return Problem(
                    title: "An error occured while creating the supplier",
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
                var supplier = new Supplier
                {

                };
                await _supplierService.CreateSupplierAsync(supplier);

                var responseDto = new SupplierDTO
                {

                };
                return CreatedAtAction(nameof(GetSupplier), new { id = supplier.SupplierId }, supplierDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Supplier");
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
                throw;
            }
            */

        }

        // Update a supplier
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateSupplier(int id, SupplierDTO supplierDto)
        {
            _logger.LogInformation($"Update Supplier request received for Id : {id}");
            if (id != supplierDto.SupplierId)
            {
                _logger.LogWarning($"Supplier ID mismatch : Route Id {id} does not match DTO ID {supplierDto.SupplierId}");
                return BadRequest("Supplier ID mismatch");
            }
            try
            {
                var existingSupplier = await _supplierService.GetSupplierByIdAsync(id);
                if (existingSupplier == null)
                {
                    _logger.LogWarning($"Supplier with ID : {id} not found");
                    return NotFound("Supplier Not Found");
                }

                _logger.LogInformation($"Updating supplier with Id {id}");
                var supplier = _mapper.Map<Supplier>(supplierDto);
                await _supplierService.UpdateSupplierAsync(supplier);

                _logger.LogInformation($"supplier with ID {id} successfully updated");
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Supplier with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
            /*
            if (id != supplierDto.SupplierId)
            {
                return BadRequest("Supplier ID mismatch.");
            }

            var existingSupplier = await _supplierService.GetSupplierByIdAsync(id);
            if (existingSupplier == null)
            {
                return NotFound("Supplier not found.");
            }

            var supplier = new Supplier
            {
                SupplierId = id,
                Name = supplierDto.SupplierName,
                PhoneNumber1 = supplierDto.PhoneNumber1,
                PhoneNumber2 = supplierDto.PhoneNumber2,
                Email = supplierDto.Email,
                Adresse = supplierDto.Adresse,
                City = supplierDto.City,
                Land = supplierDto.Land,
                IsActivate = supplierDto.IsActivate
            };

            await _supplierService.UpdateSupplierAsync(supplier);
            return NoContent();
            */
        }

        // Delete a supplier
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _supplierService.DeleteSupplierAsync(id);
            return NoContent();
        }

        //// Get Supplier by Name
        [HttpGet("Name/{name}")]
        public async Task<ActionResult<SupplierDTO>> GetSupplierByName(string name)
        {
            try
            {
                var supplier = await _supplierService.GetSupplierByNameAsync(name);
                return Ok(supplier);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving supplier by name");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPatch("{id}")]
        //[Authorize]
        public async Task<IActionResult> PatchSupplier([FromRoute] int id, [FromBody] JsonPatchDocument<SupplierDTO> patchSupplier)
        {
            if (patchSupplier == null)
            {
                return BadRequest("Invalid patch document.");
            }

            var existingSupplier = await _supplierService.GetSupplierByIdAsync(id);
            if (existingSupplier == null)
            {
                return NotFound("Supplier not found.");
            }

            var supplierDto = _mapper.Map<SupplierDTO>(existingSupplier);

            patchSupplier.ApplyTo(supplierDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(supplierDto, existingSupplier);

            await _supplierService.UpdateSupplierAsync(existingSupplier);

            return Ok(supplierDto);

            //return NoContent();

        }
    }
}
