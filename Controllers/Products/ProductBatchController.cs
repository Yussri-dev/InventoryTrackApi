using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper _mapper;

        public ProductBatchController(ProductBatchService productBatchService, ILogger<ProductBatchController> logger, IMapper mapper)
        {
            _productBatchService = productBatchService?? throw new ArgumentNullException(nameof(productBatchService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Fixed method name
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductBatchDTO>>> GetPagedProductBatches(int pageNumber = 1, int pageSize = 10)
        {
            var productBatches = await _productBatchService.GetPagedProductBatchAsync(pageNumber, pageSize);
            return Ok(productBatches);
        }

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

        [HttpPost]
        public async Task<ActionResult<ProductBatchDTO>> CreateProductBatch(ProductBatchDTO productBatchDto)
        {
            _logger.LogInformation($"Create Product Batch request for Product: {productBatchDto}");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Product Batch");
            }
            try
            {
                var product = _mapper.Map<ProductBatch>(productBatchDto);
                await _productBatchService.CreateProductBatchAsync(product);

                var responseDto = _mapper.Map<ProductBatch>(product);
                return CreatedAtAction(nameof(GetProductBatch), new { id = product.ProductId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating Product Batch : {ex.Message}");
                return Problem(
                    title: "An error occured while creating the product batch",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                    );
                throw;
            }
            /*
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
                    ReceivedDate = productBatchDto.ReceivedDate,
                    PurchasePrice = productBatchDto.PurchasePrice,  // ✅ Added
                    SalePrice = productBatchDto.SalePrice           // ✅ Added
                };

                await _productBatchService.CreateProductBatchAsync(productBatch);

                var responseDto = new ProductBatchDTO
                {
                    ProductBatchId = productBatch.ProductBatchId,
                    ProductId = productBatch.ProductId,
                    BatchNumber = productBatch.BatchNumber,
                    Quantity = productBatch.Quantity,
                    ExpirationDate = productBatch.ExpirationDate,
                    ReceivedDate = productBatch.ReceivedDate,
                    PurchasePrice = productBatch.PurchasePrice,  // ✅ Added
                    SalePrice = productBatch.SalePrice           // ✅ Added
                };

                return CreatedAtAction(nameof(GetProductBatch), new { id = productBatch.ProductBatchId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product batch"); // ✅ Fixed log message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            */
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductBatch([FromRoute]int id, ProductBatchDTO productBatchDto)
        {
            _logger.LogInformation($"Update Product request received for Id : {id}");
            if (id != productBatchDto.ProductId)
            {
                _logger.LogWarning($"Product ID mismatch : Route Id {id} does not match DTO ID {productBatchDto.ProductId}");
                return BadRequest("Product ID mismatch");
            }
            try
            {
                var existingProduct = await _productBatchService.GetProductBatchByIdAsync(id);
                if (existingProduct == null)
                {
                    _logger.LogWarning($"Product with ID : {id} not fount");
                    return NotFound("Product Not Found");
                }

                _logger.LogInformation($"Updating product with Id {id}");
                var product = _mapper.Map<ProductBatch>(productBatchDto);
                await _productBatchService.UpdateProductBatchAsync(product);

                _logger.LogInformation($"product with ID {id} successfully updated");
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Product with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
            /*
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
                ReceivedDate = productBatchDto.ReceivedDate,
                PurchasePrice = productBatchDto.PurchasePrice,  // ✅ Added
                SalePrice = productBatchDto.SalePrice           // ✅ Added
            };

            await _productBatchService.UpdateProductBatchAsync(productBatch);
            return NoContent();
            */
        }

        [HttpPut("Quantity/{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateQuantityOfProductBatch([FromRoute] int id, decimal quantity)
        {
            if (quantity == 0)
            {
                return BadRequest("Quantity must be a non-zero value.");
            }

            try
            {
                var updatedProduct = await _productBatchService.UpdateProductBatchQuantityAsync(id, quantity);
                if (updatedProduct == null)
                {
                    return NotFound("Product Batch not found.");
                }

                return Ok(updatedProduct);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the product Batch. {ex}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductBatch(int id)
        {
            await _productBatchService.DeleteProductBatchAsync(id);
            return NoContent();
        }
    }
}
