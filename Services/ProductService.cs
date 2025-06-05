using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;
        public ProductService(
           IUnitOfWork unitOfWork,
           IMapper mapper,
           ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        private const string ShelvesCacheKey = "Shelves_All";
        private const string CategoriesCacheKey = "Categories_All";
        private const string UnitsCacheKey = "Units_All";
        private const string TaxesCacheKey = "Taxes_All";
        private const string LinesCacheKey = "Lines_All";

       
        //public ProductService(
        //    IGenericRepository<Product> productRepository,
        //    IGenericRepository<Shelf> shelfRepository,
        //    IGenericRepository<Category> categoryRepository,
        //    IGenericRepository<Tax> taxRepository,
        //    IGenericRepository<Line> lineRepository,
        //    IGenericRepository<Unit> unitRepository,
        //    IUnitOfWork unitOfWork,
        //    IMapper mapper,
        //    ICacheService cacheService)
        //{
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //    _cacheService = cacheService;
        //    _productRepository = productRepository;
        //    _shelfRepository = shelfRepository;
        //    _categoryRepository = categoryRepository;
        //    _taxRepository = taxRepository;
        //    _lineRepository = lineRepository;
        //    _unitRepository = unitRepository;
        //}
        // Constructor to inject the repository
        //public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<Shelf> shelfRepository,
        //            IGenericRepository<Category> categoryRepository, IGenericRepository<Line> lineRepository,
        //            ICacheService cacheService,
        //            IGenericRepository<Unit> unitRepository, IGenericRepository<Tax> taxRepository, IMapper mapper
        //    )
        //{
        //    _productRepository = productRepository;
        //    _shelfRepository = shelfRepository;
        //    _categoryRepository = categoryRepository;
        //    _lineRepository = lineRepository;
        //    _unitRepository = unitRepository;
        //    _taxRepository = taxRepository;
        //    _cacheService = cacheService;
        //    _mapper = mapper;
        //}

        // Get all products with pagination
        public async Task<IEnumerable<Product>> GetPagedProducts(int pageNumber, int pageSize)
        {
            var cacheProducts = $"Products_Lists";
            return await _cacheService.GetOrAddAsync(cacheProducts, async () =>
            {
                return await _unitOfWork.Products.GetAllAsync(pageNumber, pageSize);
            });
        }

        // Get a product by ID
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        //Get a product by Name
        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _unitOfWork.Products.GetByNameAsync(p => p.Name.Contains(name));
        }

        //Get Product Price
        public async Task<decimal> GetProductStockQuantityAsync(int idProduit)
        {
            // Retrieve quantity Stock of product for the product
            var quantityStock = await _unitOfWork.Products.GetQuantityAsync(idProduit);
            return quantityStock;
        }

        //Get a product by Name
        public async Task<IEnumerable<Product>> GetProductByBarCodeAsync(string barCode)
        {
            return await _unitOfWork.Products.GetByBarCodeAsync(p => p.Barcode.Contains(barCode));
        }

        // Create a new product

        public async Task CreateProductAsync(Product product)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                bool exists = await _unitOfWork.Products.ExistsAsync(p =>
                p.Barcode == product.Barcode || p.Name == product.Name);

                if (product.SalePrice1 == 0 || product.PurchasePrice == 0)
                {
                    throw new InvalidOperationException("Product with sale or purchase equals 0.");
                }
                if (exists)
                {
                    throw new InvalidOperationException("Product with the same barcode or name already exists.");
                }

                await _unitOfWork.Products.CreateAsync(product);
                await _unitOfWork.CommitAsync();
                _cacheService.Remove($"Products_Lists");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
            


        }

        //Update an existing product
        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(product.ProductId);

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

            await _unitOfWork.Products.UpdateAsync(existingProduct);
        }


        //Update Quantity In Products
        public async Task<Product> UpdateProductQuantityAsync(int id, decimal quantityUpdated)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);

            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            existingProduct.QuantityStock += quantityUpdated;

            await _unitOfWork.Products.UpdateAsync(existingProduct);

            return existingProduct;
        }

        //Update Quantity In Products
        public async Task<Product> UpdateDiscountOfProduct(int id, decimal discountPourcentage)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);

            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            existingProduct.DiscountPercentage = discountPourcentage;

            await _unitOfWork.Products.UpdateAsync(existingProduct);

            return existingProduct; // Return the updated product.
        }

        // Delete a product by ID
        public async Task DeleteProductAsync(int id)
        {
            await _unitOfWork.Products.DeleteAsync(id);
        }

        //Get Product Price
        public async Task<decimal> GetProductPriceAsync(int idProduit, string priceType)
        {
            var prices = await _unitOfWork.Products.GetPricesAsync(idProduit);

            if (prices.TryGetValue(priceType, out var price))
            {
                return price;
            }
            throw new KeyNotFoundException($"Price type '{priceType}' not found for product ID {idProduit}.");
        }

        //public async Task<IEnumerable<ProductDTO>> GetDataReferencesWithProductAsync(int pageNumber, int pageSize)
        //{
        //    var productsCache = $"Products_Lists_{pageNumber}_{pageSize}";

        //    return await _cacheService.GetOrAddAsync(productsCache, async () =>
        //    {
        //        // Fetch paged products
        //        var products = await _productRepository.GetAllAsync(pageNumber, pageSize);

        //        // Fetch reference data from cache or DB

        //        var shelfMap = await GetReferenceDataAsync<Shelf>(
        //            ShelvesCacheKey,
        //            () => _shelfRepository.GetAllAsync(),
        //                            c => c.ShelfId,
        //                            c => c.Name);
        //        var categoryMap = await GetReferenceDataAsync<Category>(
        //                            CategoriesCacheKey,
        //                            () => _categoryRepository.GetAllAsync(),
        //                            c => c.CategoryId,
        //                            c => c.Name);

        //        var unitMap = await GetReferenceDataAsync<Unit>(UnitsCacheKey,
        //           () => _unitRepository.GetAllAsync(),
        //                            c => c.UnitId,
        //                            c => c.Name);
        //        var taxMap = await GetReferenceDataAsync<Tax>(
        //            TaxesCacheKey, () => _taxRepository.GetAllAsync(), 
        //                            c => c.TaxId,
        //                            c => c.TaxRate.ToString());
        //        var lineMap = await GetReferenceDataAsync<Line>(LinesCacheKey, () => _lineRepository.GetAllAsync(), // ✅ wrap in lambda
        //                            c => c.LineId,
        //                            c => c.Name);

        //        // Map products to DTOs
        //        var productDtoList = products.Select(product => new ProductDTO
        //        {
        //            ProductId = product.ProductId,
        //            ProductUnitId = product.ProductUnitId,
        //            Name = product.Name,
        //            MinStock = product.MinStock,
        //            MaxStock = product.MaxStock,
        //            PackUnitType = product.PackUnitType,
        //            QuantityStock = product.QuantityStock,
        //            QuantityPack = product.QuantityPack,
        //            Barcode = product.Barcode,
        //            PurchasePrice = product.PurchasePrice,
        //            SalePrice1 = product.SalePrice1,
        //            SalePrice2 = product.SalePrice2,
        //            SalePrice3 = product.SalePrice3,
        //            ImageUrl = product.ImageUrl,
        //            CreatedBy = product.CreatedBy,
        //            DateCreated = product.DateCreated,
        //            ModifiedBy = product.ModifiedBy,
        //            DateModified = product.DateModified,
        //            IsActivate = product.IsActivate,
        //            DiscountPercentage = product.DiscountPercentage,
        //            IsSecondItemDiscountEligible = product.IsSecondItemDiscountEligible,
        //            IsBuyThreeForFiveEligible = product.IsBuyThreeForFiveEligible,

        //            ShelfId = product.ShelfId,
        //            ShelfName = shelfMap.ContainsKey(product.ShelfId) ? shelfMap[product.ShelfId] : "Unknown",

        //            CategoryId = product.CategoryId,
        //            CategoryName = categoryMap.ContainsKey(product.CategoryId) ? categoryMap[product.CategoryId] : "Unknown",

        //            UnitId = product.UnitId,
        //            UnitName = unitMap.ContainsKey(product.UnitId) ? unitMap[product.UnitId] : "Unknown",

        //            TaxId = product.TaxId,
        //            TaxRate = taxMap.ContainsKey(product.TaxId) ? decimal.Parse(taxMap[product.TaxId]) : 0,

        //            LineId = product.LineId,
        //            LineName = lineMap.ContainsKey(product.LineId) ? lineMap[product.LineId] : "Unknown"
        //        });

        //        return productDtoList;
        //    });
        //}


        public async Task<IEnumerable<ProductDTO>> GetDataReferencesWithProductAsync(int pageNumber, int pageSize)
        {
            var productsCache = $"Products_Lists{pageNumber}_{pageSize}";
            return await _cacheService.GetOrAddAsync(productsCache, async () =>
            {
                // Fetch paged products
                var products = await _unitOfWork.Products.GetAllAsync(pageNumber, pageSize);

                // Fetch related data
                var shelves = await _unitOfWork.Shelfs.GetAllAsync();
                var categories = await _unitOfWork.Categories.GetAllAsync();
                var units = await _unitOfWork.Units.GetAllAsync();
                var taxes = await _unitOfWork.Taxes.GetAllAsync();
                var lines = await _unitOfWork.Lines.GetAllAsync();

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
            });

        }

        public async Task<int> CountProductsAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _unitOfWork.Products.CountAsync(predicate);
        }

        public async Task<int> CountProductsAsync()
        {
            return await _unitOfWork.Products.CountAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetPagedProductsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (Product)
            Expression<Func<Product, bool>> dateFilter = Product =>
                Product.DateCreated.Date >= startDate.Date && Product.DateCreated.Date <= endDate.Date;

            // Fetch Products with customer names
            var Products = await _unitOfWork.Products.GetByConditionAsync(dateFilter);

            // Map to DTO using AutoMapper
            var ProductDTOs = _mapper.Map<IEnumerable<ProductDTO>>(Products);

            return ProductDTOs;
        }
        //reusable method to cache reference data

        private async Task<Dictionary<int, string>> GetReferenceDataAsync<T>(
        string cacheKey,
        Func<Task<IEnumerable<T>>> fetchFunc,
        Func<T, int> keySelector,
        Func<T, string> valueSelector)
        {
            return await _cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var data = await fetchFunc();
                return data.ToDictionary(keySelector, valueSelector);
            });
        }
    }
}
