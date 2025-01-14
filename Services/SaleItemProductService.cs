using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryTrackApi.Services
{
    public class SaleItemProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<SaleItem> _saleItemRepository;

        public SaleItemProductService(IGenericRepository<SaleItem> saleItemRepository, 
                                      IGenericRepository<Product> productRepository)
        {
            _saleItemRepository = saleItemRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<SaleItemWithProductDTO>> GetSaleItemsWithProductAsync(int pageNumber, int pageSize)
        {
            var saleItems = await _saleItemRepository.GetAllAsync(pageNumber, pageSize);

            // Get product IDs from sale items
            var productIds = saleItems.Select(s => s.ProductId).Distinct();

            // Fetch product data
            var products = await _productRepository.GetAllAsync();
            var productMap = products.ToDictionary(p => p.ProductId);

            // Combine SaleItem and Product into SaleItemWithProductDTO
            var saleItemWithProductList = saleItems.Select(saleItem =>
            {
                var product = productMap.ContainsKey(saleItem.ProductId) ? productMap[saleItem.ProductId] : null;

                return new SaleItemWithProductDTO
                {
                    SaleItemId = saleItem.SaleItemId,
                    SaleId = saleItem.SaleId,
                    Quantity = saleItem.Quantity,
                    Price = saleItem.Price,
                    Discount = saleItem.Discount,
                    TaxAmount = saleItem.TaxAmount,
                    Total = saleItem.Total,

                    // Product fields
                    ProductName = product?.Name ?? "Unknown",
                    MinStock = product?.MinStock ?? 0,
                    MaxStock = product?.MaxStock ?? 0,
                    SalePrice = product?.SalePrice1 ?? 0,
                    DiscountPercentage = product?.DiscountPercentage ?? 0,
                    IsSecondItemDiscountEligible = product?.IsSecondItemDiscountEligible ?? false,
                    IsBuyThreeForFiveEligible = product?.IsBuyThreeForFiveEligible ?? false
                };
            });

            return saleItemWithProductList;
        }
    }
}
