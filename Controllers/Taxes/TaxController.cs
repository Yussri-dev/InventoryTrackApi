using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Taxes
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly TaxService _taxService;
        private readonly ILogger<TaxController> _logger;

        public TaxController(TaxService taxService, ILogger<TaxController> logger)
        {
            _taxService = taxService ?? throw new ArgumentNullException(nameof(taxService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //GetPaged Taxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxDTO>>> GetPagedTaxes(int pageNumber, int pageSize)
        {
            var taxes = await _taxService.GetPagedTaxs(pageNumber, pageSize);
            return Ok(taxes);
        }

        //// Get product by Name
        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<TaxDTO>> GetProductByName(decimal name)
        {
            try
            {
                var tax = await _taxService.GetTaxByNameAsync(name);
                return Ok(tax);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tax by name");
                return StatusCode(500, "Internal server error");
            }
        }

        //Get Taxe By ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxDTO>> GetTaxe(int id)
        {
            var taxe = await _taxService.GetTaxByIdAsync(id);
            if (taxe == null)
            {
                return NotFound();
            }
            return Ok(taxe);
        }

        //Createa new Taxe
        [HttpPost]
        public async Task<ActionResult<TaxDTO>> CreateTaxe(TaxDTO taxDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var tax = new Tax
                {
                    TaxRate = taxDto.TaxRate,
                };

                await _taxService.CreateTaxAsync(tax);

                var responseDto = new TaxDTO
                {
                    TaxRate = tax.TaxRate
                };

                return CreatedAtAction(nameof(GetTaxe), new { id = tax.TaxId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Update a Taxe
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaxe(int id, TaxDTO taxDto)
        {
            if (id != taxDto.TaxId)
            {
                return BadRequest("Tax ID mismatch.");
            }

            var existingTax = await _taxService.GetTaxByIdAsync(id);
            if (existingTax == null)
            {
                return NotFound("Employee not found.");
            }

            var tax = new Tax
            {
                TaxId = id,
                TaxRate = taxDto.TaxRate
            };

            await _taxService.UpdateTaxAsync(tax);
            return NoContent();
        }

        //Delete a Taxe
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxe(int id)
        {
            await _taxService.DeleteTaxAsync(id);
            return NoContent();
        }
    }
}
