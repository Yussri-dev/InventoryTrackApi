using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Suppliers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierService _supplierService;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(SupplierService supplierService, ILogger<SupplierController> logger)
        {
            _supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Get paged suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var suppliers = await _supplierService.GetPagedCutomersAsync(pageNumber, pageSize);
            return Ok(suppliers);
        }

        // Get supplier by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDTO>> GetSupplier(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        // Create a new supplier
        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> CreateSupplier(SupplierDTO supplierDto)
        {
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


        }

        // Update a supplier
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, SupplierDTO supplierDto)
        {
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
        }

        // Delete a supplier
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _supplierService.DeleteSupplierAsync(id);
            return NoContent();
        }

        //// Get Supplier by Name
        [HttpGet("ByName/{name}")]
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
    }
}
