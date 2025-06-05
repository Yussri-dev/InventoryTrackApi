using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Queries;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class ReturnItemService
    {
        //private readonly IGenericRepository<ReturnItem> _returnItemRepository;
        //private readonly IGenericRepository<Product> _productRepository;

        private readonly DiscountCalculator _discountCalculator;
        private readonly IUnitOfWork _unitOfWork;

        public ReturnItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // Constructor to inject the repository
        //public ReturnItemService(IGenericRepository<ReturnItem> returnItemRepository,
        //    IGenericRepository<Product> productRepository)
        //{
        //    _returnItemRepository = returnItemRepository;
        //    _productRepository = productRepository;
        //    _discountCalculator = new DiscountCalculator();
        //}

        //Get a product by Name
        public async Task<IEnumerable<ReturnItem>> GetReturnItemsByCodeAsync(string code)
        {
            return await _unitOfWork.ReturnItems.GetByBarCodeAsync(p => p.ReturnId.Equals(code));
        }

        // Get all returnItems with pagination
        public async Task<IEnumerable<ReturnItem>> GetPagedReturnItemsAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.ReturnItems.GetAllAsync(pageNumber, pageSize);
        }

        // Get returnItems between two dates with pagination
        public async Task<IEnumerable<ReturnItem>> GetPagedReturnItemsByDateAsync(DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            // Fetch filtered and paginated data from the repository
            return await _unitOfWork.ReturnItems.GetAllByDateRangeAsync(startDate, endDate, pageNumber, pageSize);
        }

        // Get a returnItem by ID
        public async Task<ReturnItem> GetReturnItemByIdAsync(int id)
        {
            return await _unitOfWork.ReturnItems.GetByIdAsync(id);
        }

        // Create a new returnItem
        public async Task CreateReturnItemAsync(ReturnItem returnItem)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.ReturnItems.CreateAsync(returnItem);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        // Update an existing returnItem
        public async Task UpdateReturnItemAsync(ReturnItem returnItem)
        {
            var existingReturnItem = await _unitOfWork.ReturnItems.GetByIdAsync(returnItem.ReturnItemId);
            if (existingReturnItem == null)
            {
                throw new InvalidOperationException("Return Item Not Found");
            }

            existingReturnItem.ReturnId = returnItem.ReturnItemId;
            existingReturnItem.ProductId = returnItem.ProductId;
            existingReturnItem.Quantity = returnItem.Quantity;
            existingReturnItem.RefundAmount = returnItem.RefundAmount;
            await _unitOfWork.ReturnItems.UpdateAsync(existingReturnItem);
        }

        // Delete a returnItem by ID
        public async Task DeleteReturnItemAsync(int id)
        {
            await _unitOfWork.ReturnItems.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReturnItemDTO>> GetReturnItemsWithProductAsync(int pageNumber, int pageSize)
        {
            var returnItems = await _unitOfWork.ReturnItems.GetAllAsync(pageNumber, pageSize);

            // Get product IDs from return items
            var productIds = returnItems.Select(s => s.ProductId).ToList();

            // Fetch product data
            var products = await _unitOfWork.Products.GetAllAsync();
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
