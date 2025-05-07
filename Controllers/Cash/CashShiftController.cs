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
    public class CashShiftController : ControllerBase
    {
        private readonly CashShiftService _cashShiftService;
        private readonly ILogger<CashShiftController> _logger;
        private readonly IMapper _mapper;
        public CashShiftController(CashShiftService cashShiftService, ILogger<CashShiftController> logger, IMapper mapper)
        {
            _cashShiftService = cashShiftService ?? throw new ArgumentNullException(nameof(cashShiftService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            /*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cashShift = new CashShift
                {
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

                await _cashShiftService.CreateCashShiftAsync(cashShift);

                var responseDto = new CashShiftDTO
                {
                    CashRegisterId = cashShift.CashRegisterId,
                    EmployeeId = cashShift.EmployeeId,
                    ShiftDate = cashShift.ShiftDate,
                    ShiftStart = cashShift.ShiftStart,
                    ShiftEnd = cashShift.ShiftEnd,
                    OpeningBalance = cashShift.OpeningBalance,
                    ClosingBalance = cashShift.ClosingBalance,
                    TotalSales = cashShift.TotalSales,
                    TotalRefunds = cashShift.TotalRefunds,
                    CashIn = cashShift.CashIn,
                    CashOut = cashShift.CashOut,
                };

                return CreatedAtAction(nameof(GetCashShift), new { id = cashShift.CashShiftId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            */
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

        //Delete a Cash Shift
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashShift(int id)
        {
            await _cashShiftService.DeleteCashShitAsync(id);
            return NoContent();
        }
    }
}
