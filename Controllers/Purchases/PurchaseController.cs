using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Helpers;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;


namespace InventoryTrackApi.Controllers.Purchases
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

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

        [Authorize(Roles = "Admin")]
        [HttpGet("AllPurchase")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetPagedAllPurchases([FromQuery]string userId,[FromQuery] string startDate, [FromQuery] string endDate)
        {
            if (!DateHelper.TryParseDate(startDate, out var startPurchasesDate))
            {
                return BadRequest("Invalid start date format. Use dd/MM/yyyy.");
            }

            if (!DateHelper.TryParseDate(endDate, out var endPurchasesDate))
            {
                return BadRequest("Invalid end date format. Use dd/MM/yyyy.");
            }
            var purchases = await _purchaseService.GetAllPurchaseFlatAsync(userId,startPurchasesDate, endPurchasesDate);
            return Ok(purchases);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("PurchasesAmount")]
        public async Task<ActionResult<IEnumerable<SummaryDTO>>> GetPurchasesSummaryByPeriod(DateTime startDate, DateTime endDate)
        {
            var summaries = await _purchaseService.GetSumByPeriodAsync(startDate, endDate);
            return Ok(summaries);
        }

        // Get paged purchases
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetPagedPurchases(int pageNumber = 1, int pageSize = 10)
        {
            var purchases = await _purchaseService.GetPagedPurchasesAsync(pageNumber, pageSize);
            return Ok(purchases);
        }

        // Get purchase by ID
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
                await _purchaseService.CreatePurchaseAsync(purchase, "Cash",4);

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
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchase(int id, PurchaseDTO purchaseDto)
        {
            _logger.LogInformation($"Update Purchase request received for Id : {id}");
            if (id != purchaseDto.PurchaseId)
            {
                _logger.LogWarning($"Purchase ID mismatch : Route Id {id} does not match DTO ID {purchaseDto.PurchaseId}");
                return BadRequest("Purchase ID mismatch");
            }
            try
            {
                var existingPurchase = await _purchaseService.GetPurchaseByIdAsync(id);
                if (existingPurchase == null)
                {
                    _logger.LogWarning($"Purchase with ID : {id} not found");
                    return NotFound("Purchase Not Found");
                }

                _logger.LogInformation($"Updating Purchase with Id {id}");
                var purchase = _mapper.Map<Purchase>(purchaseDto);
                await _purchaseService.UpdatePurchaseAsync(purchase);

                _logger.LogInformation($"Purchase with ID {id} successfully updated");
                return Ok(purchase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Purchase with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }

        // Delete a purchase
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            await _purchaseService.DeletePurchaseAsync(id);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
