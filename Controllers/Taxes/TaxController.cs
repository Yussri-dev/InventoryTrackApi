using AutoMapper;
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
        private readonly IMapper _mapper;

        public TaxController(TaxService taxService, ILogger<TaxController> logger, IMapper mapper)
        {
            _taxService = taxService ?? throw new ArgumentNullException(nameof(taxService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //GetPaged Taxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxDTO>>> GetPagedTaxes(int pageNumber, int pageSize)
        {
            var taxes = await _taxService.GetPagedTaxs(pageNumber, pageSize);
            return Ok(taxes);
        }

        //// Get product by Name
        [HttpGet("Rate/{Tax}")]
        public async Task<ActionResult<TaxDTO>> GetTaxByRate(decimal Tax)
        {
            try
            {
                var tax = await _taxService.GetTaxByRateAsync(Tax);
                return Ok(tax);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving Tax by Rate");
                return StatusCode(500, "Internal server error");
            }
        }

        //Get Taxe By ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxDTO>> GetTax(int id)
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
        public async Task<ActionResult<TaxDTO>> CreateTax(TaxDTO taxDto)
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

                return CreatedAtAction(nameof(GetTax), new { id = tax.TaxId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Update a Taxe
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateTax([FromRoute] int id, TaxDTO taxDto)
        {
            _logger.LogInformation($"UpdateTax request received for ID: {id}");

            if (id != taxDto.TaxId)
            {
                _logger.LogWarning($"Tax ID mismatch: Route ID {id} does not match DTO ID {taxDto.TaxId}");
                return BadRequest("Tax ID mismatch.");
            }

            try
            {
                var existingTax = await _taxService.GetTaxByIdAsync(id);
                if (existingTax == null)
                {
                    _logger.LogWarning($"Tax with ID {id} not found");
                    return NotFound("Tax not found.");
                }

                _logger.LogInformation($"Updating Tax with ID {id}");
                var tax = _mapper.Map<Tax>(taxDto);
                await _taxService.UpdateTaxAsync(tax);

                _logger.LogInformation($"Tax with ID {id} successfully updated");
                return Ok(tax);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Tax with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }

        //Delete a Taxe
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTax(int id)
        {
            await _taxService.DeleteTaxAsync(id);
            return NoContent();
        }
    }
}
