using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBatchController : ControllerBase
    {
        private readonly ProductBatchService _productBatchService;
        private readonly ILogger<ProductBatchController> _logger;

        public ProductBatchController(ProductBatchService productBatchService, ILogger<ProductBatchController> logger)
        {
            _productBatchService = productBatchService;
            _logger = logger;
        }

        // Get paged productBatchs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductBatchDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var productBatchs = await _productBatchService.GetPagedProductBatchAsync(pageNumber, pageSize);
            return Ok(productBatchs);
        }

        // Get productBatch by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBatchDTO>> GetProductBatch(int id)
        {
            var productBatch = await _productBatchService.GetProductBatchByIdAsync(id);
            if (productBatch == null)
            {
                return NotFound();
            }
            return Ok(productBatch);
        }

        // Create a new productBatch
        [HttpPost]
        public async Task<ActionResult<ProductBatchDTO>> CreateProductBatch(ProductBatchDTO productBatchDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var productBatch = new ProductBatch
                {
                    ProductId = productBatchDto.ProductId,
                    BatchNumber = productBatchDto.BatchNumber,
                    Quantity = productBatchDto.Quantity,
                    ExpirationDate = productBatchDto.ExpirationDate,
                    ReceivedDate = productBatchDto.ReceivedDate
                };

                await _productBatchService.CreateProductBatchAsync(productBatch);

                var responseDto = new ProductBatchDTO
                {
                    ProductId = productBatch.ProductId,
                    BatchNumber = productBatch.BatchNumber,
                    Quantity = productBatch.Quantity,
                    ExpirationDate = productBatch.ExpirationDate,
                    ReceivedDate = productBatch.ReceivedDate
                };

                return CreatedAtAction(nameof(GetProductBatch), new { id = productBatch.ProductBatchId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating location");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update a productBatch
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductBatch(int id, ProductBatchDTO productBatchDto)
        {
            if (id != productBatchDto.ProductBatchId)
            {
                return BadRequest("Product Batch ID mismatch.");
            }

            var existingProductBatch = await _productBatchService.GetProductBatchByIdAsync(id);
            if (existingProductBatch == null)
            {
                return NotFound("Product Batch not found.");
            }

            var productBatch = new ProductBatch
            {
                ProductBatchId = id,
                ProductId = productBatchDto.ProductId,
                BatchNumber = productBatchDto.BatchNumber,
                Quantity = productBatchDto.Quantity,
                ExpirationDate = productBatchDto.ExpirationDate,
                ReceivedDate = productBatchDto.ReceivedDate
            };

            await _productBatchService.UpdateProductBatchAsync(productBatch);
            return NoContent();
        }

        // Delete a productBatch
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductBatch(int id)
        {
            await _productBatchService.DeleteProductBatchAsync(id);
            return NoContent();
        }
    }
}
