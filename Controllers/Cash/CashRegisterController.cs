using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Cash
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashRegisterController : ControllerBase
    {
        private readonly CashRegisterService _cashRegisterService;
        private readonly ILogger<CashRegisterController> _logger;
        // Constructor to inject the service dependency
        public CashRegisterController(CashRegisterService cashRegisterService, ILogger<CashRegisterController> logger)
        {
            _cashRegisterService = cashRegisterService ?? throw new ArgumentNullException(nameof(cashRegisterService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Get paged Cash Registers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashRegisterDTO>>> GetPagedCashRegisters(int pageNumber = 1, int pageSize = 10)
        {
            var cashRegisters = await _cashRegisterService.GetPagedCashRegistersAsync(pageNumber, pageSize);
            return Ok(cashRegisters);
        }

        // Get Cash Register by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CashRegisterDTO>> GetCashRegister(int id)
        {
            var cashRegister = await _cashRegisterService.GetCashRegisterByIdAsync(id);
            if (cashRegister == null)
            {
                return NotFound("Cash register not found.");
            }
            return Ok(cashRegister);
        }

        // Create a new Cash Register
        [HttpPost]
        public async Task<ActionResult<CashRegisterDTO>> CreateCashRegister(CashRegisterDTO cashRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cashRegister = new CashRegister
                {
                    Name = cashRegisterDto.Name,
                    LocationId = cashRegisterDto.LocationId,
                    EmployeeId = cashRegisterDto.EmployeeId,
                    IsActive = cashRegisterDto.IsActive
                };

                await _cashRegisterService.CreateCashRegisterAsync(cashRegister);

                var responseDto = new CashRegisterDTO
                {
                    Name = cashRegister.Name,
                    LocationId = cashRegister.LocationId,
                    EmployeeId = cashRegister.EmployeeId,
                    IsActive = cashRegister.IsActive
                };

                return CreatedAtAction(nameof(GetCashRegister), new { id = cashRegister.CashRegisterId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update an existing Cash Register
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCashRegister(int id, CashRegisterDTO cashRegisterDto)
        {
            if (id != cashRegisterDto.CashRegisterId)
            {
                return BadRequest("Cash Register ID mismatch.");
            }

            var existingCashRegister = await _cashRegisterService.GetCashRegisterByIdAsync(id);
            if (existingCashRegister == null)
            {
                return NotFound("Cash register not found.");
            }

            var cashRegister = new CashRegister
            {
                CashRegisterId = id,
                Name = cashRegisterDto.Name,
                LocationId = cashRegisterDto.LocationId,
                EmployeeId = cashRegisterDto.EmployeeId,
                IsActive = cashRegisterDto.IsActive
            };

            await _cashRegisterService.UpdateCashRegisterAsync(cashRegister);
            return NoContent();
        }

        // Delete a Cash Register
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashRegister(int id)
        {
            var existingCashRegister = await _cashRegisterService.GetCashRegisterByIdAsync(id);
            if (existingCashRegister == null)
            {
                return NotFound("Cash register not found.");
            }

            await _cashRegisterService.DeleteCashRegisterAsync(id);
            return NoContent();
        }
    }
}
