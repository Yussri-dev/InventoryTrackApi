using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace InventoryTrackApi.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly SaleService _saleService;
        private readonly ILogger<SaleController> _logger;

        public SaleController(SaleService saleService, ILogger<SaleController> logger)
        {
            _saleService = saleService;
            _logger = logger;
        }

        // Get paged sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var sales = await _saleService.GetPagedSalesAsync(pageNumber, pageSize);
            return Ok(sales);
        }

        // Get sale by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDTO>> GetSale(int id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        // Create a new sale
        [HttpPost]
        public async Task<ActionResult<SaleDTO>> CreateSale(SaleDTO saleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // Calculate the discounted total
                var discountedTotal = await _saleService.CalculateSalesDiscountsAsync(saleDto.TotalAmount, saleDto.DiscountPercentage);

                var sale = new Sale
                {
                    SaleDate = saleDto.SaleDate,
                    CustomerId = saleDto.CustomerId,
                    EmployeeId = saleDto.EmployeeId,
                    TvaAmount = saleDto.TvaAmount,
                    TotalAmount = discountedTotal,
                    AmountPaid = saleDto.AmountPaid,
                    DiscountPercentage = saleDto.DiscountPercentage,
                };
                await _saleService.CreateSaleAsync(sale);

                var responseDto = new SaleDTO
                {
                    SaleDate = sale.SaleDate,
                    CustomerId = sale.CustomerId,
                    EmployeeId = sale.EmployeeId,
                    TvaAmount = sale.TvaAmount,
                    TotalAmount = discountedTotal,
                    AmountPaid = sale.AmountPaid,
                    DiscountPercentage = sale.DiscountPercentage

                };
                return CreatedAtAction(nameof(GetSale), new { id = sale.SaleId }, saleDto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Sale");
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }



        }

        // Update a sale
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, SaleDTO saleDto)
        {
            if (id != saleDto.SaleId)
            {
                return BadRequest("Sale ID mismatch.");
            }

            var existingSale = await _saleService.GetSaleByIdAsync(id);
            if (existingSale == null)
            {
                return NotFound("Sale not found.");
            }

            var sale = new Sale
            {
                SaleId = id,
                SaleDate = saleDto.SaleDate,
                CustomerId = saleDto.CustomerId,
                EmployeeId = saleDto.EmployeeId,
                TvaAmount = saleDto.TvaAmount,
                TotalAmount = saleDto.TotalAmount,
                AmountPaid = saleDto.AmountPaid,
            };

            await _saleService.UpdateSaleAsync(sale);
            return NoContent();
        }

        // Delete a sale
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            await _saleService.DeleteSaleAsync(id);
            return NoContent();
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetSaleCount()
        {
            try
            {
                int count = await _saleService.CountSalesAsync();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
