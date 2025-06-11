using AutoMapper;
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
        private readonly IMapper _mapper;

        public CashRegisterController(CashRegisterService cashRegisterService, 
            ILogger<CashRegisterController> logger,
            IMapper mapper)
        {
            _cashRegisterService = cashRegisterService ?? throw new ArgumentNullException(nameof(cashRegisterService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

        [HttpGet("cash/{userId}")]
        public async Task<ActionResult<CashRegisterDTO>> GetCashRegisterByUserId([FromRoute]string userId)
        {
            var cashRegister = await _cashRegisterService.GetCashRegisterByIdUserAsync(userId);
            if (cashRegister == null)
            {
                return NotFound("Cash register user not found.");
            }
            return Ok(cashRegister);
        }

        // Create a new Cash Register
        [HttpPost]
        public async Task<ActionResult<CashRegisterDTO>> CreateCashRegister(CashRegisterDTO cashRegisterDto)
        {

            _logger.LogInformation($"Create Cash Register request: {cashRegisterDto}");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating CashRegister");
            }
            try
            {
                var cashRegister = _mapper.Map<CashRegister>(cashRegisterDto);
                await _cashRegisterService.CreateCashRegisterAsync(cashRegister);

                var responseDto = _mapper.Map<CashRegisterDTO>(cashRegister);
                return CreatedAtAction(nameof(GetCashRegister), new { id = cashRegister.CashRegisterId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating Category : {ex.Message}");
                return Problem(
                    title: "An error occured while creating the cashRegister",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                    );
                throw;
            }
        }

        // Update an existing Cash Register
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCashRegister(int id, CashRegisterDTO cashRegisterDto)
        {
            _logger.LogInformation($"Update CashRegister request received for Id : {id}");
            if (id != cashRegisterDto.CashRegisterId)
            {
                _logger.LogWarning($"CashRegister ID mismatch : Route Id {id} does not match DTO ID {cashRegisterDto.CashRegisterId}");
                return BadRequest("Category ID mismatch");
            }
            try
            {
                var existingCashRegister = await _cashRegisterService.GetCashRegisterByIdAsync(id);
                if (existingCashRegister == null)
                {
                    _logger.LogWarning($"cashRegister with ID : {id} not found");
                    return NotFound("Cash Register Not Found");
                }

                _logger.LogInformation($"Updating Cash Register with Id {id}");
                var cashregister = _mapper.Map<CashRegister>(cashRegisterDto);
                await _cashRegisterService.UpdateCashRegisterAsync(cashregister);

                _logger.LogInformation($"category with ID {id} successfully updated");
                return Ok(cashregister);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Category with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
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
