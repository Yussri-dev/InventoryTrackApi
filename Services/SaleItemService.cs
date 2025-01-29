using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Queries;
using InventoryTrackApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
        //public async Task<IEnumerable<SaleItem>> GetPagedSaleItemsByDateAsync(DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        //{
        //    // Fetch filtered and paginated data from the repository
        //    return await _saleItemRepository.GetAllByDateRangeAsync(startDate, endDate, pageNumber, pageSize);
        //}

        //public async Task<IEnumerable<SaleItemDTO>> GetPagedSaleItemsByDateRangeAsync(DateTime startDate, DateTime endDate)
        //{
        //    Expression<Func<SaleItemDTO, bool>> dateFilter = saleItem => saleItem.DateCreated.Date >= startDate.Date &&
        //                                                              saleItem.DateCreated.Date <= endDate.Date;
        //    return await _saleItemRepository.GetDataByDateRange(dateFilter);
        //}
        /*
        public async Task<IEnumerable<SaleItemDTO>> GetPagedSaleItemsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (SaleItem)
            Expression<Func<SaleItem, bool>> dateFilter = saleItem =>
                saleItem.DateCreated.Date >= startDate.Date &&
                saleItem.DateCreated.Date <= endDate.Date;

            // Fetch data from the repository using the entity type
            var saleItems = await _saleItemRepository.GetDataByDateRange(dateFilter);

            // Map SaleItem entities to SaleItemDTO objects
            var saleItemDTOs = saleItems.Select(s => new SaleItemDTO
            {
                SaleItemId = s.SaleItemId,
                SaleId = s.SaleId,
                ProductId = s.ProductId,
                ProductName = s.Product.Name, // Use null-conditional operator to avoid NullReferenceException
                Quantity = s.Quantity,
                Price = s.Price,
                ProfitMarge = s.ProfitMarge,
                PurchasePrice = s.PurchasePrice,
                Discount = s.Discount,
                TaxAmount = s.TaxAmount,
                Total = s.Total,
                DateCreated = s.DateCreated
            });

            return saleItemDTOs;
        }
        */

        public async Task<IEnumerable<SaleItemDTO>> GetPagedSaleItemsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (SaleItem)
            Expression<Func<SaleItem, bool>> dateFilter = saleItem =>
                saleItem.DateCreated.Date >= startDate.Date &&
                saleItem.DateCreated.Date <= endDate.Date;

            // Fetch SaleItem entities from the repository
            var saleItems = await _saleItemRepository.GetByConditionAsync(dateFilter);

            // Fetch Product entities for the SaleItems
            var productIds = saleItems.Select(s => s.ProductId).Distinct();
            var products = await _productRepository.GetByConditionAsync(p => productIds.Contains(p.ProductId));

            // Create a dictionary for quick lookup of Product by ProductId
            var productDictionary = products.ToDictionary(p => p.ProductId, p => p);

            // Map SaleItem entities to SaleItemDTO objects
            var saleItemDTOs = saleItems.Select(s => new SaleItemDTO
            {
                SaleItemId = s.SaleItemId,
                SaleId = s.SaleId,
                ProductId = s.ProductId,
                ProductName = productDictionary.TryGetValue(s.ProductId, out var product) ? product.Name : null, // Get ProductName from the dictionary
                Quantity = s.Quantity,
                Price = s.Price,
                ProfitMarge = s.ProfitMarge,
                PurchasePrice = s.PurchasePrice,
                Discount = s.Discount,
                TaxAmount = s.TaxAmount,
                Total = s.Total,
                DateCreated = s.DateCreated
            });

            return saleItemDTOs;
        }

        public async Task<decimal> CalculateProfitsAsync(DateTime startDate)
        {
            Expression<Func<SaleItem, decimal>> profitSelector = saleItem => saleItem.ProfitMarge;
            Expression<Func<SaleItem, bool>> dateFilter = saleItem => saleItem.DateCreated.Date.Equals(startDate.Date);
            //&& saleItem.DateCreated <= endDate;

            return await _saleItemRepository.CalculateSumAsync(dateFilter, profitSelector);
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

        // Get all saleItems with pagination
        public async Task<IEnumerable<SaleItemDTO>> GetPagedSaleItemsByIdAsync(int idCode)
        {
            // Fetch sale items by barcode or ID
            var saleItems = await _saleItemRepository.GetByBarCodeAsync(p => p.SaleId.Equals(idCode));

            // Get product IDs from the fetched sale items
            var productIds = saleItems.Select(s => s.ProductId).ToList();

            // Fetch product data
            var products = await _productRepository.GetAllAsync();
            var productMap = products.ToDictionary(p => p.ProductId);

            // Combine SaleItem and Product into SaleItemDTO
            var saleItemDtoList = saleItems.Select(saleItem =>
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
                    ProductName = product?.Name ?? "Unknown", // Add ProductName
                };
            });

            return saleItemDtoList;
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

    }
}
