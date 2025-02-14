using InventoryTrackApi.DTOs;
using InventoryTrackApi.Helpers;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace InventoryTrackApi.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // Get paged products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetPagedProducts(int pageNumber = 1, int pageSize = 10)
        {
            //var products = await _productService.GetPagedProducts(pageNumber, pageSize);
            var products = await _productService.GetDataReferencesWithProductAsync(pageNumber, pageSize);
            return Ok(products);
        }


        // Get product by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //// Get product by Name
        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<ProductDTO>> GetProductByName(string name)
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
        [HttpGet("ByBarCode/{barCode}")]
        public async Task<ActionResult<ProductDTO>> GetProductByBarCode(string barCode)
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
        public async Task<ActionResult<decimal>> GetProductStockQuantity(int id)
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
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var product = new Product
                {
                    ProductUnitId = productDto.ProductUnitId,
                    Name = productDto.Name,
                    MinStock = productDto.MinStock,
                    MaxStock = productDto.MaxStock,
                    PackUnitType = productDto.PackUnitType,
                    QuantityStock = productDto.QuantityStock,
                    QuantityPack = productDto.QuantityPack,
                    Barcode = productDto.Barcode,
                    PurchasePrice = productDto.PurchasePrice,
                    SalePrice1 = productDto.SalePrice1,
                    SalePrice2 = productDto.SalePrice2,
                    SalePrice3 = productDto.SalePrice3,
                    ImageUrl = productDto.ImageUrl,
                    ModifiedBy = productDto.ModifiedBy,
                    DateModified = productDto.DateModified,
                    IsActivate = productDto.IsActivate,
                    ShelfId = productDto.ShelfId,
                    CategoryId = productDto.CategoryId,
                    UnitId = productDto.UnitId,
                    TaxId = productDto.TaxId,
                    LineId = productDto.LineId
                };
                await _productService.CreateProductAsync(product);

                var respondDto = new ProductDTO
                {
                    ProductUnitId = product.ProductUnitId,
                    Name = product.Name,
                    MinStock = product.MinStock,
                    MaxStock = product.MaxStock,
                    PackUnitType = product.PackUnitType,
                    QuantityStock = product.QuantityStock,
                    QuantityPack = product.QuantityPack,
                    Barcode = product.Barcode,
                    PurchasePrice = product.PurchasePrice,
                    SalePrice1 = product.SalePrice1,
                    SalePrice2 = product.SalePrice2,
                    SalePrice3 = product.SalePrice3,
                    ImageUrl = product.ImageUrl,
                    ModifiedBy = product.ModifiedBy,
                    DateModified = product.DateModified,
                    IsActivate = product.IsActivate,
                    ShelfId = product.ShelfId,
                    CategoryId = product.CategoryId,
                    UnitId = product.UnitId,
                    TaxId = product.TaxId,
                    LineId = product.LineId
                };
                return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, respondDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating location");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update a product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDto)
        {
            if (id != productDto.ProductId)
            {
                return BadRequest("Product ID mismatch.");
            }

            var existingProduct = await _productService.GetProductByIdAsync(id);
            //Console.WriteLine("------------------------------");
            //Console.WriteLine(existingProduct);
            //Console.WriteLine("------------------------------");
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            var product = new Product
            {
                ProductId = id,
                ProductUnitId = productDto.ProductUnitId,
                Name = productDto.Name,
                MinStock = productDto.MinStock,
                MaxStock = productDto.MaxStock,
                PackUnitType = productDto.PackUnitType,
                QuantityStock = productDto.QuantityStock,
                QuantityPack = productDto.QuantityPack,
                Barcode = productDto.Barcode,
                PurchasePrice = productDto.PurchasePrice,
                SalePrice1 = productDto.SalePrice1,
                SalePrice2 = productDto.SalePrice2,
                SalePrice3 = productDto.SalePrice3,
                ImageUrl = productDto.ImageUrl,
                ModifiedBy = productDto.ModifiedBy,
                DateModified = productDto.DateModified,
                IsActivate = productDto.IsActivate,
                ShelfId = productDto.ShelfId,
                CategoryId = productDto.CategoryId,
                UnitId = productDto.UnitId,
                TaxId = productDto.TaxId,
                LineId = productDto.LineId,
                IsSecondItemDiscountEligible = productDto.IsSecondItemDiscountEligible,
                IsBuyThreeForFiveEligible = productDto.IsBuyThreeForFiveEligible
            };

            await _productService.UpdateProductAsync(product);
            return NoContent();
        }


        [HttpPut("ByQuantity/{id}")]
        public async Task<IActionResult> UpdateQuantityOfProduct(int id, decimal quantity)
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

                return Ok(updatedProduct); // Return the updated product for client confirmation.
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // Handle specific service-layer exceptions.
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is configured) and return a generic error message.
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }

        [HttpPut("Discount/{id}")]
        public async Task<IActionResult> UpdateDiscountOfProduct(int id, decimal discount)
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

                return Ok(ProductDiscount); // Return the updated product for client confirmation.
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // Handle specific service-layer exceptions.
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is configured) and return a generic error message.
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }

        // Delete a product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        // Get product prices by ID
        [HttpGet("{id}/prices")]
        public async Task<ActionResult<Dictionary<string, decimal>>> GetProductPrices(int id, string priceType)
        {
            try
            {
                // Retrieve all prices using the service
                var prices = await _productService.GetProductPriceAsync(id, priceType);

                // If no prices are found, return NotFound
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

            // Ensure the end date is inclusive of the entire day
            //endSalesDate = DateHelper.TryParseDate(endSalesDate);

            // Fetch sales within the date range
            var products = await _productService.GetPagedProductsByDateRangeAsync(startProductsDate, endProductsDate);

            return Ok(products);
        }
    }
}
