using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class PurchaseItemService
    {
        private readonly IGenericRepository<PurchaseItem> _purchaseItemRepository;

        // Constructor to inject the repository
        public PurchaseItemService(IGenericRepository<PurchaseItem> purchaseItemRepository)
        {
            _purchaseItemRepository = purchaseItemRepository;
        }
        // Get all purchaseItems with pagination
        public async Task<IEnumerable<PurchaseItem>> GetPagedPurchaseItemsAsync(int pageNumber, int pageSize)
        {
            return await _purchaseItemRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get a purchaseItem by ID
        public async Task<PurchaseItem> GetPurchaseItemByIdAsync(int id)
        {
            return await _purchaseItemRepository.GetByIdAsync(id);
        }

        // Create a new purchaseItem
        public async Task CreatePurchaseItemAsync(PurchaseItem purchaseItem)
        {
            await _purchaseItemRepository.CreateAsync(purchaseItem);
        }

        // Update an existing purchaseItem
        public async Task UpdatePurchaseItemAsync(PurchaseItem purchaseItem)
        {
            var existingPurchaseItem = await _purchaseItemRepository.GetByIdAsync(purchaseItem.PurchaseItemId);
            if (existingPurchaseItem == null)
            {
                throw new InvalidOperationException("Purchase Item Not Found");
            }
            purchaseItem.PurchaseId = existingPurchaseItem.PurchaseId;
            purchaseItem.Quantity = existingPurchaseItem.Quantity;
            purchaseItem.Price = existingPurchaseItem.Price;
            purchaseItem.Discount = existingPurchaseItem.Discount;
            purchaseItem.TaxAmount = existingPurchaseItem.TaxAmount;
            purchaseItem.Total = existingPurchaseItem.Total;

            await _purchaseItemRepository.UpdateAsync(existingPurchaseItem);

        }

        // Delete a purchaseItem by ID
        public async Task DeletePurchaseItemAsync(int id)
        {
            await _purchaseItemRepository.DeleteAsync(id);
        }
    }
}
