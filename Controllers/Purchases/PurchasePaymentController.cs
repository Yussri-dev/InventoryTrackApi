using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Purchases
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasePaymentController : ControllerBase
    {
        private readonly PurchasePaymentService _purchasePaymentService;
        private readonly ILogger<PurchasePaymentController> _logger;

        public PurchasePaymentController(PurchasePaymentService purchasePaymentService, ILogger<PurchasePaymentController> logger)
        {
            _purchasePaymentService = purchasePaymentService;
            _logger = logger;
        }

        // Get paged purchasePayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchasePaymentDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var purchasePayments = await _purchasePaymentService.GetPagedPurchasePaymentsAsync(pageNumber, pageSize);
            return Ok(purchasePayments);
        }

        // Get purchasePayment by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchasePaymentDTO>> GetPurchasePayment(int id)
        {
            var purchasePayment = await _purchasePaymentService.GetPurchasePaymentByIdAsync(id);
            if (purchasePayment == null)
            {
                return NotFound();
            }
            return Ok(purchasePayment);
        }

        // Create a new purchasePayment
        [HttpPost]
        public async Task<ActionResult<PurchasePaymentDTO>> CreatePurchasePayment(PurchasePaymentDTO purchasePaymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var purchasePayment = new PurchasePayment
                {
                    PurchaseId = purchasePaymentDto.PurchaseId,
                    PaymentDate = purchasePaymentDto.PaymentDate,
                    Amount = purchasePaymentDto.Amount,
                    PaymentType = purchasePaymentDto.PaymentType
                };
                await _purchasePaymentService.CreatePurchasePaymentAsync(purchasePayment);

                var responseDto = new PurchasePaymentDTO
                {
                    PurchaseId = purchasePayment.PurchaseId,
                    PaymentDate = purchasePayment.PaymentDate,
                    Amount = purchasePayment.Amount,
                    PaymentType = purchasePayment.PaymentType
                };
                return CreatedAtAction(nameof(GetPurchasePayment), new { id = purchasePayment.PurchasePaymentId }, purchasePaymentDto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Purchase Payement");
                return StatusCode(500, $"Internal server Error : {ex.Message}");
            }
        }

        // Update a purchasePayment
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchasePayment(int id, PurchasePaymentDTO purchasePaymentDto)
        {
            if (id != purchasePaymentDto.PurchasePaymentId)
            {
                return BadRequest("Purchase Payment ID mismatch.");
            }

            var existingPurchasePayment = await _purchasePaymentService.GetPurchasePaymentByIdAsync(id);
            if (existingPurchasePayment == null)
            {
                return NotFound("Purchase Payment not found.");
            }

            var purchasePayment = new PurchasePayment
            {
                PurchasePaymentId = id,
                PurchaseId = purchasePaymentDto.PurchaseId,
                PaymentDate = purchasePaymentDto.PaymentDate,
                Amount = purchasePaymentDto.Amount,
                PaymentType = purchasePaymentDto.PaymentType
            };

            await _purchasePaymentService.UpdatePurchasePaymentAsync(purchasePayment);
            return NoContent();
        }

        // Delete a purchasePayment
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchasePayment(int id)
        {
            await _purchasePaymentService.DeletePurchasePaymentAsync(id);
            return NoContent();
        }
    }
}
