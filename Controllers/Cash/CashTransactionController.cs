using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Cash
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashTransactionController : ControllerBase
    {
        private readonly CashTransactionService _cashTransactionService;
        private readonly ILogger<CashTransactionController> _logger;

        public CashTransactionController(CashTransactionService cashTransactionService, ILogger<CashTransactionController> logger)
        {
            _cashTransactionService = cashTransactionService;
            _logger = logger;
        }

        //Get Paged CashTransaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashTransactionDTO>>> GetPagedCashTransactions(int pageNumber, int pageSize)
        {
            var cashTransactions = await _cashTransactionService.GetPagedCashTransactionAsync(pageNumber, pageSize);
            return Ok(cashTransactions);
        }

        //Get CashTransaction By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<CashTransactionDTO>> GetCashTransaction(int id)
        {
            var cashTransaction = await _cashTransactionService.GetCashTransactionByIdAsync(id);
            if (cashTransaction == null)
            {
                return NotFound();
            }
            return Ok(cashTransaction);
        }

        //Create a new CashTransaction
        [HttpPost]
        public async Task<ActionResult<CashTransactionDTO>> CreateCashTransaction(CashTransactionDTO cashTransactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var cashTransaction = new CashTransaction
                {
                    CashShiftId = cashTransactionDto.CashShiftId,
                    TransactionType = cashTransactionDto.TransactionType,
                    Amount = cashTransactionDto.Amount,
                    TransactionTime = cashTransactionDto.TransactionTime,
                    Description = cashTransactionDto.Description
                };
                await _cashTransactionService.CreateCashTransactionAsync(cashTransaction);

                var responseDto = new CashTransaction
                {
                    CashShiftId = cashTransaction.CashShiftId,
                    TransactionType = cashTransaction.TransactionType,
                    Amount = cashTransaction.Amount,
                    TransactionTime = cashTransaction.TransactionTime,
                    Description = cashTransaction.Description
                };

                return CreatedAtAction(nameof(GetCashTransaction), new { id = cashTransaction.CashTransactionId }, responseDto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Update a CashTransaction
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCashTransaction(int id, CashTransactionDTO cashTransactionDto)
        {
            if (id != cashTransactionDto.CashTransactionId)
            {
                return BadRequest("Cash Transaction Id Mismatch");
            }

            var existingCashTransaction = await _cashTransactionService.GetCashTransactionByIdAsync(id);
            if (existingCashTransaction == null)
            {
                return NotFound("Cash Transaction not found.");
            }

            var cashTransaction = new CashTransaction
            {
                CashTransactionId = id,
                CashShiftId = cashTransactionDto.CashShiftId,
                TransactionType = cashTransactionDto.TransactionType,
                Amount = cashTransactionDto.Amount,
                TransactionTime = cashTransactionDto.TransactionTime,
                Description = cashTransactionDto.Description
            };
            await _cashTransactionService.UpdateCashTransactionAsync(cashTransaction);
            return NoContent();
        }

        //Delete a Cash Transaction
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashTransaction(int id)
        {
            await _cashTransactionService.DeleteCashTransactionAsync(id);
            return NoContent();
        }
    }
}
