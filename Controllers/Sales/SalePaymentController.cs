using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace InventoryTrackApi.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePaymentController : ControllerBase
    {
        private readonly SalePaymentService _SalePaymentService;
        private readonly ILogger<SalePaymentController> _logger;
        private readonly IMapper _mapper;
        public SalePaymentController(
            SalePaymentService SalePaymentService,
            ILogger<SalePaymentController> logger, IMapper mapper)
        {
            _SalePaymentService = SalePaymentService;
            _logger = logger;
            _mapper = mapper;
        }

        // Get paged SalePayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalePaymentDTO>>> GetPagedSalePayments(int pageNumber = 1, int pageSize = 10)
        {
            var SalePayments = await _SalePaymentService.GetPagedSalePaymentAsync(pageNumber, pageSize);
            return Ok(SalePayments);
        }

        [HttpGet("SalePaymentsDateRange")]
        public async Task<ActionResult<IEnumerable<SalePaymentDTO>>> GetPagedSalePaymentsByDateRangeAsync(
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
            var SalePayments = await _SalePaymentService.GetPagedSalePaymentsByDateRangeAsync(startSalesDate, endSalesDate);

            return Ok(SalePayments);
        }

        // Get SalePayment by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SalePaymentDTO>> GetSalePayment(int id)
        {
            var SalePayment = await _SalePaymentService.GetSalePaymentByIdAsync(id);
            if (SalePayment == null)
            {
                return NotFound();
            }
            return Ok(SalePayment);
        }

        ////// Get SalePayment by ID
        //[HttpGet("ByBarCode/{id}")]
        //public async Task<ActionResult<SalePaymentDTO>> GetSalePaymentByBarCode(int id)
        //{
        //    try
        //    {
        //        var SalePayment = await _SalePaymentService.get(id);
        //        return Ok(SalePayment);
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error retrieving SalePayment by name");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}


        // Create a new SalePayment
        [HttpPost]
        public async Task<ActionResult<SalePaymentDTO>> CreateSalePayment(SalePaymentDTO SalePaymentDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for Create Sale Item.");
                return ValidationProblem(ModelState);
            }
            try
            {
                var sale = _mapper.Map<SalePayment>(SalePaymentDto);
                await _SalePaymentService.CreateSalePaymentAsync(sale);

                var respondDto = _mapper.Map<SalePaymentDTO>(sale);
                return CreatedAtAction(nameof(GetSalePayment), new { id = sale.SalePaymentId }, respondDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Sale: {Message}", ex.Message);
                return Problem(
                    title: "An error occurred while creating the purchase.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

        }

        //// Update a SalePayment

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateSalePayment([FromRoute] int id, SalePaymentDTO SalePaymentDto)
        {
            _logger.LogInformation($"Update SalePayment request received for Id : {id}");
            if (id != SalePaymentDto.SalePaymentId)
            {
                _logger.LogWarning($"SalePayment ID mismatch : Route Id {id} does not match DTO ID {SalePaymentDto.SalePaymentId}");
                return BadRequest("SalePayment ID mismatch");
            }
            try
            {
                var existingSalePayment = await _SalePaymentService.GetSalePaymentByIdAsync(id);
                if (existingSalePayment == null)
                {
                    _logger.LogWarning($"SalePayment with ID : {id} not fount");
                    return NotFound("SalePayment Not Found");
                }

                _logger.LogInformation($"Updating SalePayment with Id {id}");
                var SalePayment = _mapper.Map<SalePayment>(SalePaymentDto);
                await _SalePaymentService.UpdateSalePaymentAsync(SalePayment);

                _logger.LogInformation($"SalePayment with ID {id} successfully updated");
                return Ok(SalePayment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating SalePayment with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }

        // Delete a SalePayment
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalePayment(int id)
        {
            await _SalePaymentService.DeleteSalePaymentAsync(id);
            return NoContent();
        }

        //[HttpGet("profits")]
        //public async Task<ActionResult<decimal>> CalculateProfits([FromQuery] string startDate)
        //{
        //    try
        //    {
        //        if (!DateTime.TryParseExact(
        //            startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
        //            out var parsedStartDate))
        //        {
        //            return BadRequest("Invalid date format. Use dd/MM/yyyy.");
        //        }

        //        var totalProfits = await _SalePaymentService.CalculateProfitsAsync(parsedStartDate);

        //        //Return the decimal value directly instead of JSON
        //        return Ok(totalProfits);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}

        ////GetCustomerSalesAsync(int customerId)
        //[HttpGet("SalePayments/{id}")]
        //public async Task<ActionResult<IEnumerable<SaleDTO>>> GetCustomerSalesAsync(int id)
        //{
        //    // Fetch sales within the date range
        //    var SalePayments = await _SalePaymentService.GetSalesItemByIdAsync(id);

        //    return Ok(SalePayments);
        //}
    }
}
