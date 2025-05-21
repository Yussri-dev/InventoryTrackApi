using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class ProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Shelf> _shelfRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Line> _lineRepository;
        private readonly IGenericRepository<Unit> _unitRepository;
        private readonly IGenericRepository<Tax> _taxRepository;
        private readonly IMapper _mapper;

        // Constructor to inject the repository
        public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<Shelf> shelfRepository,
                    IGenericRepository<Category> categoryRepository, IGenericRepository<Line> lineRepository,
                    IGenericRepository<Unit> unitRepository, IGenericRepository<Tax> taxRepository, IMapper mapper
            )
        {
            _productRepository = productRepository;
            _shelfRepository = shelfRepository;
            _categoryRepository = categoryRepository;
            _lineRepository = lineRepository;
            _unitRepository = unitRepository;
            _taxRepository = taxRepository;
            _mapper = mapper;
        }

        // Get all products with pagination
        public async Task<IEnumerable<Product>> GetPagedProducts(int pageNumber, int pageSize)
        {
            return await _productRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get a product by ID
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        //Get a product by Name
        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _productRepository.GetByNameAsync(p => p.Name.Contains(name));
        }

        //Get Product Price
        public async Task<decimal> GetProductStockQuantityAsync(int idProduit)
        {
            // Retrieve quantity Stock of product for the product
            var quantityStock = await _productRepository.GetQuantityAsync(idProduit);
            return quantityStock;
        }

        //Get a product by Name
        public async Task<IEnumerable<Product>> GetProductByBarCodeAsync(string barCode)
        {
            return await _productRepository.GetByBarCodeAsync(p => p.Barcode.Contains(barCode));
        }

        // Create a new product

        public async Task CreateProductAsync(Product product)
        {
            bool exists = await _productRepository.ExistsAsync(p =>
                p.Barcode == product.Barcode || p.Name == product.Name);

            if (product.SalePrice1 == 0 || product.PurchasePrice == 0)
            {
                throw new InvalidOperationException("Product with sale or purchase equals 0.");
            }
            if (exists)
            {
                throw new InvalidOperationException("Product with the same barcode or name already exists.");
            }

            await _productRepository.CreateAsync(product);
        }

        //Update an existing product
        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.ProductId);

            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product Not Found");
            }

            existingProduct.ProductUnitId = product.ProductUnitId;
            existingProduct.Name = product.Name;
            existingProduct.MinStock = product.MinStock;
            existingProduct.MaxStock = product.MaxStock;
            existingProduct.PackUnitType = product.PackUnitType;
            existingProduct.QuantityStock = product.QuantityStock;
            existingProduct.QuantityPack = product.QuantityPack;
            existingProduct.Barcode = product.Barcode;
            existingProduct.PurchasePrice = product.PurchasePrice;
            existingProduct.SalePrice1 = product.SalePrice1;
            existingProduct.SalePrice2 = product.SalePrice2;
            existingProduct.SalePrice3 = product.SalePrice3;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.ModifiedBy = product.ModifiedBy;
            existingProduct.DateModified = product.DateModified;
            existingProduct.IsActivate = product.IsActivate;

            await _productRepository.UpdateAsync(existingProduct);
        }

        
        //Update Quantity In Products
        public async Task<Product> UpdateProductQuantityAsync(int id, decimal quantityUpdated)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            existingProduct.QuantityStock += quantityUpdated;

            await _productRepository.UpdateAsync(existingProduct);

            return existingProduct; // Return the updated product.
        }

        //Update Quantity In Products
        public async Task<Product> UpdateDiscountOfProduct(int id, decimal discountPourcentage)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            existingProduct.DiscountPercentage = discountPourcentage;

            await _productRepository.UpdateAsync(existingProduct);

            return existingProduct; // Return the updated product.
        }

        // Delete a product by ID
        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        //Get Product Price
        public async Task<decimal> GetProductPriceAsync(int idProduit, string priceType)
        {
            var prices = await _productRepository.GetPricesAsync(idProduit);

            if (prices.TryGetValue(priceType, out var price))
            {
                return price;
            }
            throw new KeyNotFoundException($"Price type '{priceType}' not found for product ID {idProduit}.");
        }

        public async Task<IEnumerable<ProductDTO>> GetDataReferencesWithProductAsync(int pageNumber, int pageSize)
        {
            // Fetch paged products
            var products = await _productRepository.GetAllAsync(pageNumber, pageSize);

            // Fetch related data
            var shelves = await _shelfRepository.GetAllAsync(); 
            var categories = await _categoryRepository.GetAllAsync();
            var units = await _unitRepository.GetAllAsync(); 
            var taxes = await _taxRepository.GetAllAsync(); 
            var lines = await _lineRepository.GetAllAsync();

            // Create dictionaries for efficient lookups
            var shelfMap = shelves.ToDictionary(s => s.ShelfId, s => s.Name);
            var categoryMap = categories.ToDictionary(c => c.CategoryId, c => c.Name);
            var unitMap = units.ToDictionary(u => u.UnitId, u => u.Name);
            var taxMap = taxes.ToDictionary(t => t.TaxId, t => t.TaxRate);
            var lineMap = lines.ToDictionary(l => l.LineId, l => l.Name);

            // Map products to ProductDTO including references
            var productDtoList = products.Select(product => new ProductDTO
            {
                ProductId = product.ProductId,
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
                CreatedBy = product.CreatedBy,
                DateCreated = product.DateCreated,
                ModifiedBy = product.ModifiedBy,
                DateModified = product.DateModified,
                IsActivate = product.IsActivate,
                DiscountPercentage = product.DiscountPercentage,
                IsSecondItemDiscountEligible = product.IsSecondItemDiscountEligible,
                IsBuyThreeForFiveEligible = product.IsBuyThreeForFiveEligible,

                ShelfId = product.ShelfId,
                ShelfName = shelfMap.ContainsKey(product.ShelfId) ? shelfMap[product.ShelfId] : "Unknown",

                CategoryId = product.CategoryId,
                CategoryName = categoryMap.ContainsKey(product.CategoryId) ? categoryMap[product.CategoryId] : "Unknown",

                UnitId = product.UnitId,
                UnitName = unitMap.ContainsKey(product.UnitId) ? unitMap[product.UnitId] : "Unknown",

                TaxId = product.TaxId,
                TaxRate = taxMap.ContainsKey(product.TaxId) ? taxMap[product.TaxId] : 0,

                LineId = product.LineId,
                LineName = lineMap.ContainsKey(product.LineId) ? lineMap[product.LineId] : "Unknown"
            });

            return productDtoList;
        }

        public async Task<int> CountProductsAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _productRepository.CountAsync(predicate);
        }

        public async Task<int> CountProductsAsync()
        {
            return await _productRepository.CountAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetPagedProductsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (Product)
            Expression<Func<Product, bool>> dateFilter = Product =>
                Product.DateCreated.Date >= startDate.Date && Product.DateCreated.Date <= endDate.Date;

            // Fetch Products with customer names
            var Products = await _productRepository.GetByConditionAsync(dateFilter);

            // Map to DTO using AutoMapper
            var ProductDTOs = _mapper.Map<IEnumerable<ProductDTO>>(Products);

            return ProductDTOs;
        }
    }
}
