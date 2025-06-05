using AutoMapper;
using InventoryTrackApi.Calculations;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using InventoryTrackApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Cash
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashShiftController : ControllerBase
    {
        private readonly CashShiftService _cashShiftService;
        private readonly CashCountCalculator _calculator;
        private readonly ILogger<CashShiftController> _logger;
        private readonly IMapper _mapper;

        public CashShiftController(CashShiftService cashShiftService, ILogger<CashShiftController> logger, IMapper mapper)
        {
            _cashShiftService = cashShiftService ?? throw new ArgumentNullException(nameof(cashShiftService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _calculator = new CashCountCalculator();
        }

        //Get Paged CashShift
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashShiftDTO>>> GetPagedCashShifts(int pageNumber, int pageSize)
        {
            var cashShifts = await _cashShiftService.GetPagedCashShifts(pageNumber, pageSize);
            return Ok(cashShifts);
        }

        //Get CashShift By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<CashShiftDTO>> GetCashShift(int id)
        {
            var cashShift = await _cashShiftService.GetCashShiftByIdAsync(id);
            if (cashShift == null)
            {
                return NotFound();
            }
            return Ok(cashShift);
        }

        [HttpGet("Drawer/{idUser}")]
        public async Task<ActionResult<IEnumerable<CashShiftDTO>>> GetCashShiftByIdAndDate([FromRoute]int idUser)
        {
            var cashShift = await _cashShiftService.GetCashShiftByIdAndDateAsync(idUser);
            if (cashShift == null)
            {
                return NotFound();
            }
            return Ok(cashShift);
        }
        //Create a new CashShift
        [HttpPost]
        public async Task<ActionResult<CashShiftDTO>> CreateCashShift(CashShiftDTO cashShiftDto)
        {
            _logger.LogInformation($"Create CashShift request for Cash Shift: {cashShiftDto}");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Customer");
            }
            try
            {
                var cashShift = _mapper.Map<CashShift>(cashShiftDto);
                await _cashShiftService.CreateCashShiftAsync(cashShift);

                var responseDto = _mapper.Map<CashShiftDTO>(cashShift);
                return CreatedAtAction(nameof(GetCashShift), new { id = cashShift.CashShiftId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating CashShift : {ex.Message}");
                return Problem(
                    title: "An error occured while creating the cashShift",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                    );
                throw;
            }
        }

        [HttpPost("close/{shiftId}")]
        public async Task<ActionResult<CashShiftCloseResultDto>> CloseShift([FromRoute] int shiftId, [FromBody] CashShiftActualDto request)
        {
            if (request.Cash == 0)
            {
                _logger.LogWarning("Cash count data is null");
                return BadRequest("Cash count data is required.");
            }

            try
            {
                var result = await _cashShiftService.CloseCashShiftAsync(shiftId, request.Cash);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, $"Invalid operation closing shift {shiftId}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error closing shift {shiftId}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        //Update a CashShift
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCashShift(int id, CashShiftDTO cashShiftDto)
        {
            _logger.LogInformation($"Update CashShift request received for Id : {id}");
            if (id != cashShiftDto.CashShiftId)
            {
                _logger.LogWarning($"CashShift ID mismatch : Route Id {id} does not match DTO ID {cashShiftDto.CashShiftId}");
                return BadRequest("CashShift ID mismatch");
            }
            try
            {
                var exisitingCashShift = await _cashShiftService.GetCashShiftByIdAsync(id);
                if (exisitingCashShift == null)
                {
                    _logger.LogWarning($"CashShift with ID : {id} not found");
                    return NotFound("CashShift Not Found");
                }

                _logger.LogInformation($"Updating CashShift with Id {id}");
                var customer = _mapper.Map<CashShift>(cashShiftDto);
                await _cashShiftService.UpdateCashShiftAsync(customer);

                _logger.LogInformation($"CashShift with ID {id} successfully updated");
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating CashShift with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
            /*
            if (id != cashShiftDto.CashShiftId)
            {
                return BadRequest("CashShift ID mismatch.");
            }

            var existingCashShift = await _cashShiftService.GetCashShiftByIdAsync(id);
            if (existingCashShift == null)
            {
                return NotFound("CashShift not found.");
            }

            var cashShift = new CashShift
            {
                CashShiftId = id,
                CashRegisterId = cashShiftDto.CashRegisterId,
                EmployeeId = cashShiftDto.EmployeeId,
                ShiftDate = cashShiftDto.ShiftDate,
                ShiftStart = cashShiftDto.ShiftStart,
                ShiftEnd = cashShiftDto.ShiftEnd,
                OpeningBalance = cashShiftDto.OpeningBalance,
                ClosingBalance = cashShiftDto.ClosingBalance,
                TotalSales = cashShiftDto.TotalSales,
                TotalRefunds = cashShiftDto.TotalRefunds,
                CashIn = cashShiftDto.CashIn,
                CashOut = cashShiftDto.CashOut,

            };

            await _cashShiftService.UpdateCashShiftAsync(cashShift);
            return NoContent();
            */
        }

        [HttpPost("calculate")]
        public ActionResult<CashCountResultDto> Calculate([FromBody] CashCountDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid input.");

            var result = _calculator.CalculateTotals(dto);
            return Ok(result);
        }
        //Delete a Cash Shift
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashShift(int id)
        {
            await _cashShiftService.DeleteCashShitAsync(id);
            return NoContent();
        }
    }
}
