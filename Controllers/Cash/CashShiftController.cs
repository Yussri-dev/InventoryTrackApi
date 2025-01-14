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
        public CashShiftController(CashShiftService cashShiftService, ILogger<CashShiftController> logger)
        {
            _cashShiftService = cashShiftService;
            _logger = logger;
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
        }

        //Update a CashShift
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCashShift(int id, CashShiftDTO cashShiftDto)
        {
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
