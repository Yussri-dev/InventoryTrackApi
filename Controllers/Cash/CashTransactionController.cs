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
    public class CashTransactionController : ControllerBase
    {
        private readonly CashTransactionService _cashTransactionService;
        private readonly ILogger<CashTransactionController> _logger;
        private readonly IMapper _mapper;
        public CashTransactionController(CashTransactionService cashTransactionService,
            ILogger<CashTransactionController> logger,
            IMapper mapper)
        {
            _cashTransactionService = cashTransactionService?? throw new ArgumentNullException(nameof(cashTransactionService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

        //Create a new CashShift
        [HttpPost]
        public async Task<ActionResult<CashTransactionDTO>> CreateCashTransaction(CashTransactionDTO cashTransactionDto)
        {

            _logger.LogInformation($"Create CashTransaction request for Cash Transaction: {cashTransactionDto}");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Cash Transaction");
            }
            try
            {
                var cashShift = _mapper.Map<CashTransaction>(cashTransactionDto);
                await _cashTransactionService.CreateCashTransactionAsync(cashShift);

                var responseDto = _mapper.Map<CashTransactionDTO>(cashShift);
                return CreatedAtAction(nameof(GetCashTransaction), new { id = cashShift.CashTransactionId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating CashTransaction : {ex.Message}");
                return Problem(
                    title: "An error occured while creating the cashTransaction",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                    );
                throw;
            }
        }



        //Create a new CashTransaction



        /*[HttpPost]
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
        */
        //Update a CashTransaction
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCashTransaction(int id, CashTransactionDTO cashTransactionDto)
        {
            _logger.LogInformation($"Update CashTransaction request received for Id : {id}");
            if (id != cashTransactionDto.CashTransactionId)
            {
                _logger.LogWarning($"CashTransaction ID mismatch : Route Id {id} does not match DTO ID {cashTransactionDto.CashTransactionId}");
                return BadRequest("CashTransaction ID mismatch");
            }
            try
            {
                var existingCustomer = await _cashTransactionService.GetCashTransactionByIdAsync(id);
                if (existingCustomer == null)
                {
                    _logger.LogWarning($"Cash Transaction with ID : {id} not found");
                    return NotFound("Cash Transaction Not Found");
                }

                _logger.LogInformation($"Updating CashTransaction with Id {id}");
                var cashTransaction = _mapper.Map<CashTransaction>(cashTransactionDto);
                await _cashTransactionService.UpdateCashTransactionAsync(cashTransaction);

                _logger.LogInformation($"Cash Transaction with ID {id} successfully updated");
                return Ok(cashTransaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Cash Transaction with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
            /*
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
            */
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
