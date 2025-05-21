using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Helpers;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Purchases
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PurchaseItemController : ControllerBase
    {
        private readonly PurchaseItemService _purchaseItemService;
        private readonly ILogger<PurchaseItemController> _logger;
        private readonly IMapper _mapper;

        public PurchaseItemController(PurchaseItemService purchaseItemService, 
            ILogger<PurchaseItemController> logger,
            IMapper mapper)
        {
            _purchaseItemService = purchaseItemService?? throw new ArgumentNullException(nameof(purchaseItemService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get paged purchaseItems
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<PurchaseItemDTO>>> GetPagedPurchaseItem(int pageNumber = 1, int pageSize = 10)
        {
            var purchaseItems = await _purchaseItemService.GetPagedPurchaseItemsAsync(pageNumber, pageSize);
            return Ok(purchaseItems);
        }

        // Get purchaseItem by ID
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<PurchaseItemDTO>> GetPurchaseItem(int id)
        {
            var purchaseItem = await _purchaseItemService.GetPurchaseItemByIdAsync(id);
            if (purchaseItem == null)
            {
                return NotFound();
            }
            return Ok(purchaseItem);
        }

        // Create a new saleItem
        [HttpPost]
        public async Task<ActionResult<PurchaseItemDTO>> CreatePurchaseItem(PurchaseItemDTO purchaseItemDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for Create Purchase Item.");
                return ValidationProblem(ModelState);
            }
            try
            {
                var purchase = _mapper.Map<PurchaseItem>(purchaseItemDto);
                await _purchaseItemService.CreatePurchaseItemAsync(purchase);

                var respondDto = _mapper.Map<PurchaseItemDTO>(purchase);
                return CreatedAtAction(nameof(GetPurchaseItem), new { id = purchase.PurchaseItemId }, respondDto);
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
        //[HttpGet("purchaseItems")]
        //public async Task<ActionResult<PurchaseItemDTO>> GetPurchaseItemWithPurchaseAndProduct()
        //{
        //    var purchaseItems = await _purchaseItemService.GetPagedPurchaseItemsAsync(int pageNumber = 1, int pageSize = 10);
        //    if (purchaseItems == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(purchaseItems);
        //}
        // Create a new purchaseItem
        //[HttpPost]
        //[Authorize]

        /*
        public async Task<ActionResult<PurchaseItemDTO>> CreatePurchaseItem(PurchaseItemDTO purchaseItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var purchaseItem = new PurchaseItem
                {
                    PurchaseId = purchaseItemDto.PurchaseId,
                    ProductId = purchaseItemDto.ProductId,
                    Quantity = purchaseItemDto.Quantity,
                    Price = purchaseItemDto.Price,
                    Discount = purchaseItemDto.Discount,
                    TaxAmount = purchaseItemDto.TaxAmount,
                    Total = purchaseItemDto.Total
                };
                await _purchaseItemService.CreatePurchaseItemAsync(purchaseItem);
                var respondDto = new PurchaseItemDTO
                {
                    PurchaseId = purchaseItem.PurchaseId,
                    ProductId = purchaseItem.ProductId,
                    Quantity = purchaseItem.Quantity,
                    Price = purchaseItem.Price,
                    Discount = purchaseItem.Discount,
                    TaxAmount = purchaseItem.TaxAmount,
                    Total = purchaseItem.Total
                };
                return CreatedAtAction(nameof(GetPurchaseItem), new { id = purchaseItem.PurchaseItemId }, purchaseItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Purchase Item");
                return StatusCode(500, $"Internal server error : {ex.Message}");
            }

        }
        */

        // Update a purchaseItem
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdatePurchaseItem([FromRoute] int id, PurchaseItemDTO purchaseItemDto)
        {
            _logger.LogInformation($"Update PurchaseItem request received for Id : {id}");
            if (id != purchaseItemDto.PurchaseItemId)
            {
                _logger.LogWarning($"PurchaseItem ID mismatch : Route Id {id} does not match DTO ID {purchaseItemDto.PurchaseItemId}");
                return BadRequest("PurchaseItem ID mismatch");
            }
            try
            {
                var existingPurchaseItem = await _purchaseItemService.GetPurchaseItemByIdAsync(id);
                if (existingPurchaseItem == null)
                {
                    _logger.LogWarning($"PurchaseItem with ID : {id} not fount");
                    return NotFound("PurchaseItem Not Found");
                }

                _logger.LogInformation($"Updating purchaseItem with Id {id}");
                var purchaseItem = _mapper.Map<PurchaseItem>(purchaseItemDto);
                await _purchaseItemService.UpdatePurchaseItemAsync(purchaseItem);

                _logger.LogInformation($"purchaseItem with ID {id} successfully updated");
                return Ok(purchaseItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating PurchaseItem with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }
        
        //public async Task<IActionResult> UpdatePurchaseItem(int id, PurchaseItemDTO purchaseItemDto)
        //{
        //    if (id != purchaseItemDto.PurchaseItemId)
        //    {
        //        return BadRequest("Purchase Item ID mismatch.");
        //    }

        //    var existingPurchaseItem = await _purchaseItemService.GetPurchaseItemByIdAsync(id);
        //    if (existingPurchaseItem == null)
        //    {
        //        return NotFound("Purchase Item not found.");
        //    }

        //    var purchaseItem = new PurchaseItem
        //    {
        //        PurchaseItemId = id,
        //        PurchaseId = purchaseItemDto.PurchaseId,
        //        ProductId = purchaseItemDto.ProductId,
        //        Quantity = purchaseItemDto.Quantity,
        //        Price = purchaseItemDto.Price,
        //        Discount = purchaseItemDto.Discount,
        //        TaxAmount = purchaseItemDto.TaxAmount,
        //        Total = purchaseItemDto.Total
        //    };

        //    await _purchaseItemService.UpdatePurchaseItemAsync(purchaseItem);
        //    return NoContent();
        //}

        // Delete a purchaseItem
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeletePurchaseItem(int id)
        {
            await _purchaseItemService.DeletePurchaseItemAsync(id);
            return NoContent();
        }

        [HttpGet("PurchaseItemsDateRange")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<PurchaseItemDTO>>> GetPagedPurchaseItemsByDateRangeAsync(
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
            var purchases = await _purchaseItemService.GetPagedPurchaseItemsByDateRangeAsync(startPurchasesDate, endPurchasesDate);

            return Ok(purchases);
        }
    }
}
