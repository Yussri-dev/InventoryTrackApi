using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Queries;
using InventoryTrackApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Services
{
    public class SaleItemService
    {
        private readonly IGenericRepository<SaleItem> _saleItemRepository;
        private readonly IGenericRepository<Product> _productRepository;

        private readonly DiscountCalculator _discountCalculator;

        // Constructor to inject the repository
        public SaleItemService(IGenericRepository<SaleItem> saleItemRepository,
            IGenericRepository<Product> productRepository)
        {
            _saleItemRepository = saleItemRepository;
            _productRepository = productRepository;
            _discountCalculator = new DiscountCalculator();
        }

        // Get all saleItems with pagination
        public async Task<IEnumerable<SaleItem>> GetPagedSaleItemsAsync(int pageNumber, int pageSize)
        {
            return await _saleItemRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get saleItems between two dates with pagination
        public async Task<IEnumerable<SaleItem>> GetPagedSaleItemsByDateAsync(DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            // Fetch filtered and paginated data from the repository
            return await _saleItemRepository.GetAllByDateRangeAsync(startDate, endDate, pageNumber, pageSize);
        }

        // Get a saleItem by ID
        public async Task<SaleItem> GetSaleItemByIdAsync(int id)
        {
            return await _saleItemRepository.GetByIdAsync(id);
        }

        // Create a new saleItem
        public async Task CreateSaleItemAsync(SaleItem saleItem)
        {
            await _saleItemRepository.CreateAsync(saleItem);
        }

        // Update an existing saleItem
        public async Task UpdateSaleItemAsync(SaleItem saleItem)
        {
            var existingSaleItem = await _saleItemRepository.GetByIdAsync(saleItem.SaleItemId);
            if (existingSaleItem == null)
            {
                throw new InvalidOperationException("Sale Item Not Found");
            }

            existingSaleItem.SaleId = saleItem.SaleItemId;
            existingSaleItem.Quantity = saleItem.Quantity;
            existingSaleItem.Price = saleItem.Price;
            existingSaleItem.Discount = saleItem.Discount;
            existingSaleItem.TaxAmount = saleItem.TaxAmount;
            existingSaleItem.Total = saleItem.Total;

            await _saleItemRepository.UpdateAsync(existingSaleItem);
        }

        // Delete a saleItem by ID
        public async Task DeleteSaleItemAsync(int id)
        {
            await _saleItemRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SaleItemDTO>> GetSaleItemsWithProductAsync(int pageNumber, int pageSize)
        {
            var saleItems = await _saleItemRepository.GetAllAsync(pageNumber, pageSize);

            // Get product IDs from sale items
            var productIds = saleItems.Select(s => s.ProductId).ToList();

            // Fetch product data
            var products = await _productRepository.GetAllAsync();
            var productMap = products.ToDictionary(p => p.ProductId);

            // Combine SaleItem and Product into SaleItemWithProductDTO
            var saleItemWithProductList = saleItems.Select(saleItem =>
            {
                var product = productMap.ContainsKey(saleItem.ProductId) ? productMap[saleItem.ProductId] : null;

                return new SaleItemDTO
                {
                    SaleItemId = saleItem.SaleItemId,
                    SaleId = saleItem.SaleId,
                    ProductId = saleItem.ProductId,
                    Quantity = saleItem.Quantity,
                    Price = saleItem.Price,
                    Discount = saleItem.Discount,
                    TaxAmount = saleItem.TaxAmount,
                    Total = saleItem.Total,
                    ProductName = product?.Name ?? "Unknown",
                };
            });

            return saleItemWithProductList;
        }

        //public async Task<IEnumerable<SaleItemDTO>> GetDataReferencesWithSaleItemAsync(int pageNumber, int pageSize)
        //{
        //    // Fetch paged sale items
        //    var saleItems = await _saleItemRepository.GetAllAsync(pageNumber, pageSize);

        //    // Fetch related data
        //    var products = await _productRepository.GetAllAsync(); // Assuming a repository for products

        //    // Create a dictionary for efficient lookups
        //    var productMap = products.ToDictionary(p => p.ProductId, p => p.Name);

        //    // Map sale items to SaleItemDTO including references
        //    var saleItemDtoList = saleItems.Select(saleItem => new SaleItemDTO
        //    {
        //        SaleItemId = saleItem.SaleItemId,
        //        SaleId = saleItem.SaleId,
        //        ProductId = saleItem.ProductId,
        //        Quantity = saleItem.Quantity,
        //        Price = saleItem.Price,
        //        Discount = saleItem.Discount,
        //        TaxAmount = saleItem.TaxAmount,
        //        Total = saleItem.Total,
        //        ProductName = productMap.ContainsKey(saleItem.ProductId) ? productMap[saleItem.ProductId] : "Unknown"

        //    });

        //    return saleItemDtoList;
        //}


    }
}
