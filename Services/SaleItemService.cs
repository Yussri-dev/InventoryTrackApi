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
        private readonly DiscountCalculator _discountCalculator;

        // Constructor to inject the repository
        public SaleItemService(IGenericRepository<SaleItem> saleItemRepository, IGenericRepository<Product> productRepository)
        {
            _saleItemRepository = saleItemRepository;
            _discountCalculator = new DiscountCalculator();
        }
        // Get all saleItems with pagination
        public async Task<IEnumerable<SaleItem>> GetPagedSaleItemsAsync(int pageNumber, int pageSize)
        {
            return await _saleItemRepository.GetAllAsync(pageNumber, pageSize);
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

       
    }
}
