using InventoryTrackApi.Controllers.Returns;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Returns
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnController : ControllerBase
    {
        private readonly ReturnService _ReturnService;
        private readonly ILogger<ReturnController> _logger;

        public ReturnController(ReturnService ReturnService, ILogger<ReturnController> logger)
        {
            _ReturnService = ReturnService;
            _logger = logger;
        }

        // Get paged Returns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnDTO>>> GetPagedReturns(int pageNumber = 1, int pageSize = 10)
        {
            var Returns = await _ReturnService.GetPagedReturnsAsync(pageNumber, pageSize);
            return Ok(Returns);
        }

        // Get Return by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnDTO>> GetReturn(int id)
        {
            var Return = await _ReturnService.GetReturnByIdAsync(id);
            if (Return == null)
            {
                return NotFound();
            }
            return Ok(Return);
        }

        // Create a new Return
        [HttpPost]
        public async Task<ActionResult<ReturnDTO>> CreateReturn(ReturnDTO ReturnDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // Calculate the discounted total
                //var discountedTotal = await _ReturnService.CalculateReturnsDiscountsAsync(ReturnDto.TotalAmount, ReturnDto.DiscountPercentage);

                var Return = new Return
                {
                    ReturnDate = ReturnDto.returnDate,
                    CustomerId = ReturnDto.CustomerId,
                    UserId = ReturnDto.UserId,
                    RefundAmount = ReturnDto.RefundAmount,
                    Reason = ReturnDto.Reason,
                    ReturnMethod = ReturnDto.ReturnMethod,
                    Status = ReturnDto.Status,
                    SaleId = ReturnDto.SaleId,
                    DateCreated = DateTime.Now
                };
                await _ReturnService.CreateReturnAsync(Return);

                var responseDto = new ReturnDTO
                {
                    returnDate = Return.ReturnDate,
                    CustomerId = Return.CustomerId,
                    UserId = Return.UserId,
                    RefundAmount = ReturnDto.RefundAmount,
                    Reason = ReturnDto.Reason,
                    ReturnMethod = ReturnDto.ReturnMethod,
                    Status = ReturnDto.Status,
                    SaleId = ReturnDto.SaleId,
                    DateCreated = DateTime.Now
                };
                return CreatedAtAction(nameof(GetReturn), new { id = Return.ReturnId }, ReturnDto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Return");
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }



        }

        // Update a Return
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReturn(int id, ReturnDTO ReturnDto)
        {
            if (id != ReturnDto.ReturnId)
            {
                return BadRequest("Return ID mismatch.");
            }

            var existingReturn = await _ReturnService.GetReturnByIdAsync(id);
            if (existingReturn == null)
            {
                return NotFound("Return not found.");
            }

            var Return = new Return
            {
                ReturnId = id,
                ReturnDate = ReturnDto.returnDate,
                CustomerId = ReturnDto.CustomerId,
                UserId = ReturnDto.UserId,
                RefundAmount = ReturnDto.RefundAmount,
                Reason = ReturnDto.Reason,
                ReturnMethod = ReturnDto.ReturnMethod,
                Status = ReturnDto.Status,
                SaleId = ReturnDto.SaleId,
            };

            await _ReturnService.UpdateReturnAsync(Return);
            return NoContent();
        }

        // Delete a Return
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturn(int id)
        {
            await _ReturnService.DeleteReturnAsync(id);
            return NoContent();
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetReturnCount()
        {
            try
            {
                int count = await _ReturnService.CountReturnsAsync();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
