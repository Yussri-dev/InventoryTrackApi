using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Helpers;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace InventoryTrackApi.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(ProductService productService, ILogger<ProductController> logger, IMapper mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get paged products
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetPagedProducts(int pageNumber = 1, int pageSize = 10)
        {
            var products = await _productService.GetDataReferencesWithProductAsync(pageNumber, pageSize);
            return Ok(products);
        }


        // Get product by ID
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<ProductDTO>> GetProduct([FromRoute] int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //// Get product by Name
        [HttpGet("Name/{name}")]
        //[Authorize]
        public async Task<ActionResult<ProductDTO>> GetProductByName([FromRoute]string name)
        {
            try
            {
                var product = await _productService.GetProductByNameAsync(name);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product by name");
                return StatusCode(500, "Internal server error");
            }
        }

        //// Get product by ID
        [HttpGet("BarCode/{barCode}")]
        //[Authorize]
        public async Task<ActionResult<ProductDTO>> GetProductByBarCode([FromRoute] string barCode)
        {
            try
            {
                var product = await _productService.GetProductByBarCodeAsync(barCode);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product by name");
                return StatusCode(500, "Internal server error");
            }
        }

        //Get stock Product by Id
        [HttpGet("QuantityStock/{id}")]
        //[Authorize]
        public async Task<ActionResult<decimal>> GetProductStockQuantity([FromRoute] int id)
        {
            try
            {
                var productQuantity = await _productService.GetProductStockQuantityAsync(id);
                return Ok(productQuantity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product by Id");
                return StatusCode(500, "Internal server error");
            }
        }

        // Create a new product
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO productDto)
        {
            _logger.LogInformation($"Create Product request for Product: {productDto}");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Product");
            }
            try
            {
                var product = _mapper.Map<Product>(productDto);
                await _productService.CreateProductAsync(product);

                var responseDto = _mapper.Map<ProductDTO>(product);
                return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating Product : {ex.Message}");
                return Problem(
                    title: "An error occured while creating the product",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                    );
                throw;
            }
            /*
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for Creating P.");
                return ValidationProblem(ModelState);
            }
            try
            {
                var product = _mapper.Map<Product>(productDto);
                await _productService.CreateProductAsync(product);

                var respondDto = _mapper.Map<ProductDTO>(product);
                return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, respondDto);
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
           */
        }

        // Update a product
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, ProductDTO productDto)
        {
            _logger.LogInformation($"Update Product request received for Id : {id}");
            if (id != productDto.ProductId)
            {
                _logger.LogWarning($"Product ID mismatch : Route Id {id} does not match DTO ID {productDto.ProductId}");
                return BadRequest("Product ID mismatch");
            }
            try
            {
                var existingProduct = await _productService.GetProductByIdAsync(id);
                if (existingProduct == null)
                {
                    _logger.LogWarning($"Product with ID : {id} not fount");
                    return NotFound("Product Not Found");
                }

                _logger.LogInformation($"Updating product with Id {id}");
                var product = _mapper.Map<Product>(productDto);
                await _productService.UpdateProductAsync(product);

                _logger.LogInformation($"product with ID {id} successfully updated");
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Product with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpPut("Quantity/{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateQuantityOfProduct([FromRoute] int id, decimal quantity)
        {
            if (quantity == 0)
            {
                return BadRequest("Quantity must be a non-zero value.");
            }

            try
            {
                var updatedProduct = await _productService.UpdateProductQuantityAsync(id, quantity);
                if (updatedProduct == null)
                {
                    return NotFound("Product not found.");
                }

                return Ok(updatedProduct);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the product. {ex}");
            }
        }

        [HttpPut("Discount/{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateDiscountOfProduct([FromRoute] int id, decimal discount)
        {
            if (discount == 0)
            {
                return BadRequest("Quantity must be a non-zero value.");
            }

            try
            {
                var ProductDiscount = await _productService.UpdateDiscountOfProduct(id, discount);
                if (ProductDiscount == null)
                {
                    return NotFound("Product not found.");
                }

                return Ok(ProductDiscount);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the product. {ex}");
            }
        }

        // Delete a product
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        // Get product prices by ID
        [HttpGet("{id}/prices")]
        //[Authorize]
        public async Task<ActionResult<Dictionary<string, decimal>>> GetProductPrices(int id, string priceType)
        {
            try
            {
                var prices = await _productService.GetProductPriceAsync(id, priceType);

                if (prices.ToString() == null)
                {
                    return NotFound("No prices found for the given product.");
                }

                return Ok(prices);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product prices");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("countBarCode")]
        //[Authorize]
        public async Task<ActionResult<int>> GetProductCount([FromQuery] string barCode)
        {
            try
            {
                // Create a predicate for filtering
                Expression<Func<Product, bool>> predicate = p => true;

                if (!string.IsNullOrEmpty(barCode))
                {
                    predicate = p => p.Barcode.Contains(barCode);
                }

                int count = await _productService.CountProductsAsync(predicate);
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("count")]
        //[Authorize]
        public async Task<ActionResult<int>> GetSaleCount()
        {
            try
            {
                int count = await _productService.CountProductsAsync();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("ProductsDateRange")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetPagedSalesByDateRangeAsync(
                [FromQuery] string startDate, [FromQuery] string endDate)
        {
            if (!DateHelper.TryParseDate(startDate, out var startProductsDate))
            {
                return BadRequest("Invalid start date format. Use dd/MM/yyyy.");
            }

            if (!DateHelper.TryParseDate(endDate, out var endProductsDate))
            {
                return BadRequest("Invalid end date format. Use dd/MM/yyyy.");
            }

            var products = await _productService.GetPagedProductsByDateRangeAsync(startProductsDate, endProductsDate);

            return Ok(products);
        }
    }
}
