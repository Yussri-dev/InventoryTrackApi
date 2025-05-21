using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class PurchaseItemService
    {
        private readonly IGenericRepository<PurchaseItem> _purchaseItemRepository;
        private readonly IMapper _mapper;
        // Constructor to inject the repository
        public PurchaseItemService(IGenericRepository<PurchaseItem> purchaseItemRepository, IMapper mapper)
        {
            _purchaseItemRepository = purchaseItemRepository;
            _mapper = mapper;
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
            existingPurchaseItem.PurchaseId = purchaseItem.PurchaseId;
            existingPurchaseItem.Quantity = purchaseItem.Quantity;
            existingPurchaseItem.Price = purchaseItem.Price;
            existingPurchaseItem.Discount = purchaseItem.Discount;
            existingPurchaseItem.TaxAmount = purchaseItem.TaxAmount;
            existingPurchaseItem.Total = purchaseItem.Total;
            existingPurchaseItem.SaasClientId = purchaseItem.SaasClientId;

            await _purchaseItemRepository.UpdateAsync(existingPurchaseItem);

        }

        // Delete a purchaseItem by ID
        public async Task DeletePurchaseItemAsync(int id)
        {
            await _purchaseItemRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PurchaseItemDTO>> GetPagedPurchaseItemsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (purchaseItem)
            Expression<Func<PurchaseItem, bool>> dateFilter = purchaseItem =>
                purchaseItem.DateCreated.Date >= startDate.Date && purchaseItem.DateCreated.Date <= endDate.Date;

            // Fetch sales with customer names
            var purchaseItems = await _purchaseItemRepository.GetByConditionAsync(dateFilter, "Product");

            // Map to DTO using AutoMapper
            var purchaseItemDTOs = _mapper.Map<IEnumerable<PurchaseItemDTO>>(purchaseItems);

            return purchaseItemDTOs;
        }
    }
}
