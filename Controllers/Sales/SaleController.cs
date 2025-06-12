using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Helpers;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq.Expressions;
using System.Net;

namespace InventoryTrackApi.Controllers.Sales
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class SaleController : ControllerBase
    {
        private readonly SaleService _saleService;
        private readonly ILogger<SaleController> _logger;
        private readonly IMapper _mapper;

        public SaleController(
            SaleService saleService,
            ILogger<SaleController> logger,
            IMapper mapper)
        {
            _saleService = saleService ?? throw new ArgumentNullException(nameof(saleService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("AllSale/{userId}")]
        [MapToApiVersion("2.0")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetPagedAllSales([FromQuery] string userId, [FromQuery] string startDate, string endDate)
        {
            if (!DateHelper.TryParseDate(startDate, out var startPurchasesDate))
            {
                return BadRequest("Invalid start date format. Use dd/MM/yyyy.");
            }

            if (!DateHelper.TryParseDate(endDate, out var endPurchasesDate))
            {
                return BadRequest("Invalid end date format. Use dd/MM/yyyy.");
            }
            var purchases = await _saleService.GetAllSaleFlatAsync(userId, startPurchasesDate, endPurchasesDate);
            return Ok(purchases);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("AllSale")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetPagedAllSales([FromQuery] string startDate, string endDate)
        {
            if (!DateHelper.TryParseDate(startDate, out var startPurchasesDate))
            {
                return BadRequest("Invalid start date format. Use dd/MM/yyyy.");
            }

            if (!DateHelper.TryParseDate(endDate, out var endPurchasesDate))
            {
                return BadRequest("Invalid end date format. Use dd/MM/yyyy.");
            }
            var purchases = await _saleService.GetAllSaleFlatAsync(startPurchasesDate, endPurchasesDate);
            return Ok(purchases);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("monthly-summary")]
        public async Task<ActionResult<IEnumerable<MonthlySummaryDTO>>> GetMonthlySummary([FromQuery] string userId,
            [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            var start = startDate ?? DateTime.Today.AddMonths(-6);
            var end = endDate ?? DateTime.Today;

            try
            {
                var monthlySummaries = await _saleService.GetMonthlySummaryAsync(userId, start, end);
                return Ok(monthlySummaries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving monthly summary", error = ex.Message });
            }
        }

        // Get paged sales
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetPagedSales(int pageNumber = 1, int pageSize = 10)
        {
            var sales = await _saleService.GetPagedSalesAsync(pageNumber, pageSize);
            return Ok(sales);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("SalesAmount")]
        public async Task<ActionResult<IEnumerable<SummaryDTO>>> GetSalesSummaryByPeriod(DateTime startDate, DateTime endDate)
        {
            var summaries = await _saleService.GetSumByPeriodAsync(startDate, endDate);
            return Ok(summaries);
        }

        // Get sale by ID
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<SaleDTO>> CreateSale(SaleDTO saleDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for Create Sale.");
                return ValidationProblem(ModelState);
            }
            try
            {
                var sale = _mapper.Map<Sale>(saleDto);
                await _saleService.CreateSaleAsync(sale, "Cash", 4);

                var respondDto = _mapper.Map<SaleDTO>(sale);
                return CreatedAtAction(nameof(GetSale), new { id = sale.SaleId }, respondDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Sale: {Message}", ex.Message);
                return Problem(
                    title: "An error occurred while creating the sale.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

        }

        // Update a sale
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, SaleDTO saleDto)
        {
            _logger.LogInformation($"Update Sale request received for Id : {id}");
            if (id != saleDto.SaleId)
            {
                _logger.LogWarning($"Sale ID mismatch : Route Id {id} does not match DTO ID {saleDto.SaleId}");
                return BadRequest("Sale ID mismatch");
            }
            try
            {
                var existingSale = await _saleService.GetSaleByIdAsync(id);
                if (existingSale == null)
                {
                    _logger.LogWarning($"Sale with ID : {id} not fount");
                    return NotFound("Sale Not Found");
                }

                _logger.LogInformation($"Updating sale with Id {id}");
                var sale = _mapper.Map<Sale>(saleDto);
                await _saleService.UpdateSaleAsync(sale);

                _logger.LogInformation($"sale with ID {id} successfully updated");
                return Ok(sale);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Sale with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }

        // Delete a sale
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            await _saleService.DeleteSaleAsync(id);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet("SalesDateRange")]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetPagedSalesByDateRangeAsync(
                [FromQuery] string startDate, [FromQuery] string endDate)
        {
            if (!DateHelper.TryParseDate(startDate, out var startSalesDate))
            {
                return BadRequest("Invalid start date format. Use dd/MM/yyyy.");
            }

            if (!DateHelper.TryParseDate(endDate, out var endSalesDate))
            {
                return BadRequest("Invalid end date format. Use dd/MM/yyyy.");
            }

            // Fetch sales within the date range
            var sales = await _saleService.GetPagedSalesByDateRangeAsync(startSalesDate, endSalesDate);

            return Ok(sales);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("CustomerSales")]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetCustomerSalesAsync(
                [FromQuery] int saleId)
        {
            // Fetch sales within the date range
            var Salesales = await _saleService.GetCustomerSalesAsync(saleId);

            return Ok(Salesales);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("apply-payment/{saleId}")]
        public async Task<IActionResult> ApplyPaymentToInvoices([FromRoute] int saleId, [FromQuery] decimal paymentAmount)
        {
            try
            {
                if (paymentAmount <= 0)
                {
                    return BadRequest("Payment amount must be greater than zero.");
                }

                await _saleService.ApplyPaymentToInvoicesAsync(saleId, paymentAmount);

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid input provided.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while applying payment.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

    }
}
