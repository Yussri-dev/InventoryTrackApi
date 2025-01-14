using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePaymentController : ControllerBase
    {
        private readonly SalePaymentService _salePaymentService;

        public SalePaymentController(SalePaymentService salePaymentService)
        {
            _salePaymentService = salePaymentService;
        }

        // Get paged salePayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalePaymentDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var salePayments = await _salePaymentService.GetPagedSalePaymentAsync(pageNumber, pageSize);
            return Ok(salePayments);
        }

        // Get salePayment by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SalePaymentDTO>> GetSalePayment(int id)
        {
            var salePayment = await _salePaymentService.GetSalePaymentByIdAsync(id);
            if (salePayment == null)
            {
                return NotFound();
            }
            return Ok(salePayment);
        }

        // Create a new salePayment
        [HttpPost]
        public async Task<ActionResult<SalePaymentDTO>> CreateSalePayment(SalePaymentDTO salePaymentDto)
        {
            var salePayment = new SalePayment
            {
                // Map SalePaymentDTO to SalePayment entity here
            };

            await _salePaymentService.CreateSalePaymentAsync(salePayment);

            return CreatedAtAction(nameof(GetSalePayment), new { id = salePayment.SalePaymentId }, salePaymentDto);
        }

        // Update a salePayment
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalePayment(int id, SalePaymentDTO salePaymentDto)
        {
            if (id != salePaymentDto.SalePaymentId)
            {
                return BadRequest("Sale Payment ID mismatch.");
            }

            var existingSalePayment = await _salePaymentService.GetSalePaymentByIdAsync(id);
            if (existingSalePayment == null)
            {
                return NotFound("Sale Payment not found.");
            }

            var salePayment = new SalePayment
            {
                SalePaymentId = id,
                SaleId = salePaymentDto.SaleId,
                PaymentDate = salePaymentDto.PaymentDate,
                Amount = salePaymentDto.Amount,
                PaymentType = salePaymentDto.PaymentType
            };

            await _salePaymentService.UpdateSalePaymentAsync(salePayment);
            return NoContent();
        }

        // Delete a salePayment
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalePayment(int id)
        {
            await _salePaymentService.DeleteSalePaymentAsync(id);
            return NoContent();
        }
    }
}
