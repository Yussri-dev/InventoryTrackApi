using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Helpers;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;


namespace InventoryTrackApi.Controllers.Purchases
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly PurchaseService _purchaseService;
        private readonly ILogger<PurchaseController> _logger;
        private readonly IMapper _mapper;
        public PurchaseController(PurchaseService purchaseService, ILogger<PurchaseController> logger, IMapper mapper)
        {
            _purchaseService = purchaseService ?? throw new ArgumentNullException(nameof(purchaseService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get paged purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetPagedPurchases(int pageNumber = 1, int pageSize = 10)
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
                _logger.LogWarning("Purchase with ID {Id} not found.", id);
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
                _logger.LogWarning("Invalid model state for CreatePurchase.");
                return ValidationProblem(ModelState);
            }
            try
            {
                var purchase = _mapper.Map<Purchase>(purchaseDto);
                await _purchaseService.CreatePurchaseAsync(purchase);

                var respondDto = _mapper.Map<PurchaseDTO>(purchase);
                return CreatedAtAction(nameof(GetPurchase), new { id = purchase.PurchaseId }, respondDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Purchase: {Message}", ex.Message);
                return Problem(
                    title: "An error occurred while creating the purchase.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
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

            var purchase = _mapper.Map<Purchase>(purchaseDto);
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
                _logger.LogError(ex, "Error getting purchase count.");
                return Problem(
                    title: "An error occurred while getting the purchase count.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        [HttpGet("PurchasesDateRange")]
        public async Task<ActionResult<IEnumerable<SaleItemDTO>>> GetPagedPurchasesByDateRangeAsync(
            [FromQuery] string startDate, [FromQuery] string endDate)
        {
            if (!DateHelper.TryParseDate(startDate, out var startPurchasesDate))
            {
                return BadRequest("Invalid start date format. Use dd/MM/yyyy.");
            }

            if (!DateHelper.TryParseDate(endDate, out var endPurchasesDate))
            {
                return BadRequest("Invalid end date format. Use dd/MM/yyyy.");
            }

            // Ensure the end date is inclusive of the entire day
            endPurchasesDate = endPurchasesDate.AddDays(1).AddSeconds(-1);

            // Fetch purchases within the date range
            var purchases = await _purchaseService.GetPagedPurchasesByDateRangeAsync(startPurchasesDate, endPurchasesDate);

            return Ok(purchases);
        }
        
    }
}
