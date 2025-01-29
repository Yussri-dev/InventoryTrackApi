using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Queries;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class ReturnItemService
    {
        private readonly IGenericRepository<ReturnItem> _returnItemRepository;
        private readonly IGenericRepository<Product> _productRepository;

        private readonly DiscountCalculator _discountCalculator;

        // Constructor to inject the repository
        public ReturnItemService(IGenericRepository<ReturnItem> returnItemRepository,
            IGenericRepository<Product> productRepository)
        {
            _returnItemRepository = returnItemRepository;
            _productRepository = productRepository;
            _discountCalculator = new DiscountCalculator();
        }

        //Get a product by Name
        public async Task<IEnumerable<ReturnItem>> GetReturnItemsByCodeAsync(string code)
        {
            return await _returnItemRepository.GetByBarCodeAsync(p => p.ReturnId.Equals(code));
        }

        // Get all returnItems with pagination
        public async Task<IEnumerable<ReturnItem>> GetPagedReturnItemsAsync(int pageNumber, int pageSize)
        {
            return await _returnItemRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get returnItems between two dates with pagination
        public async Task<IEnumerable<ReturnItem>> GetPagedReturnItemsByDateAsync(DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            // Fetch filtered and paginated data from the repository
            return await _returnItemRepository.GetAllByDateRangeAsync(startDate, endDate, pageNumber, pageSize);
        }

        // Get a returnItem by ID
        public async Task<ReturnItem> GetReturnItemByIdAsync(int id)
        {
            return await _returnItemRepository.GetByIdAsync(id);
        }

        // Create a new returnItem
        public async Task CreateReturnItemAsync(ReturnItem returnItem)
        {
            await _returnItemRepository.CreateAsync(returnItem);
        }

        // Update an existing returnItem
        public async Task UpdateReturnItemAsync(ReturnItem returnItem)
        {
            var existingReturnItem = await _returnItemRepository.GetByIdAsync(returnItem.ReturnItemId);
            if (existingReturnItem == null)
            {
                throw new InvalidOperationException("Return Item Not Found");
            }

            existingReturnItem.ReturnId = returnItem.ReturnItemId;
            existingReturnItem.ProductId = returnItem.ProductId;
            existingReturnItem.Quantity = returnItem.Quantity;
            existingReturnItem.RefundAmount = returnItem.RefundAmount;
            await _returnItemRepository.UpdateAsync(existingReturnItem);
        }

        // Delete a returnItem by ID
        public async Task DeleteReturnItemAsync(int id)
        {
            await _returnItemRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReturnItemDTO>> GetReturnItemsWithProductAsync(int pageNumber, int pageSize)
        {
            var returnItems = await _returnItemRepository.GetAllAsync(pageNumber, pageSize);

            // Get product IDs from return items
            var productIds = returnItems.Select(s => s.ProductId).ToList();

            // Fetch product data
            var products = await _productRepository.GetAllAsync();
            var productMap = products.ToDictionary(p => p.ProductId);

            // Combine ReturnItem and Product into ReturnItemWithProductDTO
            var returnItemWithProductList = returnItems.Select(returnItem =>
            {
                var product = productMap.ContainsKey(returnItem.ProductId) ? productMap[returnItem.ProductId] : null;

                return new ReturnItemDTO
                {
                    ReturnItemId = returnItem.ReturnItemId,
                    ReturnId = returnItem.ReturnId,
                    ProductId = returnItem.ProductId,
                    Quantity = returnItem.Quantity,
                    RefundAmount = returnItem.RefundAmount,
                    ProductName = product?.Name ?? "Unknown",
                };
            });

            return returnItemWithProductList;
        }

    }
}
