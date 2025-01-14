using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleItemWithProductController : ControllerBase
    {
        private readonly SaleItemProductService _saleItemProductService;

        public SaleItemWithProductController(SaleItemProductService saleItemProductService)
        {
            _saleItemProductService = saleItemProductService;
        }

        // Endpoint to get SaleItemWithProductDTO with pagination
        [HttpGet]
        public async Task<IActionResult> GetSaleItemsWithProduct([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _saleItemProductService.GetSaleItemsWithProductAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred :{ex.Message} ");
            }
        }
    }
}
