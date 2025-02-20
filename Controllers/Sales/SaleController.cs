using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Helpers;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq.Expressions;
using System.Net;

namespace InventoryTrackApi.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
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

        // Get paged sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetPagedSales(int pageNumber = 1, int pageSize = 10)
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
            //if (!ModelState.IsValid)
            //{
            //    _logger.LogWarning("Invalid model state for Create Sale.");
            //    return ValidationProblem(ModelState);
            //}
            //try
            //{
            //    var sale = _mapper.Map<Sale>(saleDTO);
            //    await _saleService.CreateSaleAsync(sale);

            //    var respondDto = _mapper.Map<SaleDTO>(sale);
            //    return CreatedAtAction(nameof(GetSale), new { id = sale.SaleId }, respondDto);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Error Creating Sale: {Message}", ex.Message);
            //    return Problem(
            //        title: "An error occurred while creating the sale.",
            //        detail: ex.Message,
            //        statusCode: StatusCodes.Status500InternalServerError
            //    );
            //}

            ///*
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

            //*/

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
        /*
        [HttpGet("SalesDateRange")]
        public async Task<ActionResult<IEnumerable<SaleItemDTO>>> GetPagedSalesByDateRangeAsync(
                    [FromQuery] string startDate, [FromQuery] string endDate)
        {
            // Parse the start date
            if (!DateTime.TryParseExact(
                    startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out var startSalesDate))
            {
                return BadRequest("Invalid start date format. Use dd/MM/yyyy.");
            }

            // Parse the end date
            if (!DateTime.TryParseExact(
                    endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out var endSalesDate))
            {
                return BadRequest("Invalid end date format. Use dd/MM/yyyy.");
            }

            // Ensure the end date is inclusive of the entire day
            endSalesDate = endSalesDate.AddDays(1).AddSeconds(-1);

            // Fetch sale items within the date range
            var saleItems = await _saleService.GetPagedSalesByDateRangeAsync(startSalesDate, endSalesDate);

            return Ok(saleItems);
        }
        */

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

        [HttpGet("CustomerSales")]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetCustomerSalesAsync(
                [FromQuery] int customerId)
        {
            // Fetch sales within the date range
            var Customersales = await _saleService.GetCustomerSalesAsync(customerId);

            return Ok(Customersales);
        }

        [HttpPut("apply-payment/{customerId}")]
        public async Task<IActionResult> ApplyPaymentToInvoices([FromRoute] int customerId, [FromQuery] decimal paymentAmount)
        {
            try
            {
                if (paymentAmount <= 0)
                {
                    return BadRequest("Payment amount must be greater than zero.");
                }

                await _saleService.ApplyPaymentToInvoicesAsync(customerId, paymentAmount);

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
        //[HttpPut("apply-payment")]
        ////[ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        ////[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        ////[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //public async Task<IActionResult> ApplyPaymentToInvoices(int customerId, decimal paymentAmount)
        //{
        //    try
        //    {
        //        // Validate input
        //        if (customerId <= 0)
        //        {
        //            return BadRequest(new { Message = "Customer ID must be greater than zero." });
        //        }

        //        if (paymentAmount <= 0)
        //        {
        //            return BadRequest(new { Message = "Payment amount must be greater than zero." });
        //        }

        //        await _saleService.ApplyPaymentToInvoicesAsync(customerId, paymentAmount);

        //        return Ok(await _saleService.GetCustomerSalesAsync(customerId));
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        // Handle invalid input exceptions
        //        _logger.LogWarning(ex, "Invalid input provided.");
        //        return BadRequest(new { Message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log and handle unexpected errors
        //        _logger.LogError(ex, "An unexpected error occurred while applying payment.");
        //        return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred." });
        //    }
        //}



    }
}
