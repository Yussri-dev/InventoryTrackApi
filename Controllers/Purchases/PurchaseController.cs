using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Purchases
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly PurchaseService _purchaseService;
        private readonly ILogger<PurchaseController> _logger;
        public PurchaseController(PurchaseService purchaseService, ILogger<PurchaseController> logger)
        {
            _purchaseService = purchaseService;
            _logger = logger;
        }

        // Get paged purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var purchases = await _purchaseService.GetPagedPurchasesAsync(pageNumber, pageSize);
            return Ok(purchases);
        }

        // Get purchase by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDTO>> GetPurchase(int id)
        {
            var purchase = await _purchaseService.GetPurchaseByIdAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase);
        }

        // Create a new purchase
        [HttpPost]
        public async Task<ActionResult<PurchaseDTO>> CreatePurchase(PurchaseDTO purchaseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var purchase = new Purchase
                {
                    PurchaseDate = purchaseDto.PurchaseDate,
                    SupplierId = purchaseDto.SupplierId,
                    EmployeeId = purchaseDto.EmployeeId,
                    TvaAmount = purchaseDto.TvaAmount,
                    TotalAmount = purchaseDto.TotalAmount,
                    AmountPaid = purchaseDto.AmountPaid
                };
                await _purchaseService.CreatePurchaseAsync(purchase);

                var respondDto = new PurchaseDTO
                {
                    PurchaseDate = purchase.PurchaseDate,
                    SupplierId = purchase.SupplierId,
                    EmployeeId = purchase.EmployeeId,
                    TvaAmount = purchase.TvaAmount,
                    TotalAmount = purchase.TotalAmount,
                    AmountPaid = purchase.AmountPaid
                };
                return CreatedAtAction(nameof(GetPurchase), new { id = purchase.PurchaseId }, purchaseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Purchase");
                return StatusCode(500, $"Internal Server Error {ex.Message}");
            }

        }

        // Update a purchase
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchase(int id, PurchaseDTO purchaseDto)
        {
            if (id != purchaseDto.PurchaseId)
            {
                return BadRequest("Purchase ID mismatch.");
            }

            var existingPurchase = await _purchaseService.GetPurchaseByIdAsync(id);
            if (existingPurchase == null)
            {
                return NotFound("Purchase not found.");
            }

            var purchase = new Purchase
            {
                PurchaseId = id,
                PurchaseDate = purchaseDto.PurchaseDate,
                SupplierId = purchaseDto.SupplierId,
                EmployeeId = purchaseDto.EmployeeId,
                TvaAmount = purchaseDto.TvaAmount,
                TotalAmount = purchaseDto.TotalAmount,
                AmountPaid = purchaseDto.AmountPaid
            };


            await _purchaseService.UpdatePurchaseAsync(purchase);
            return NoContent();
        }

        // Delete a purchase
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            await _purchaseService.DeletePurchaseAsync(id);
            return NoContent();
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetPurchaseCount()
        {
            try
            {
                int count = await _purchaseService.CountPurchasesAsync();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
