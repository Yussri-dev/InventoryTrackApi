using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class PurchaseService
    {
        private readonly IGenericRepository<Purchase> _purchaseRepository;

        // Constructor to inject the repository
        public PurchaseService(IGenericRepository<Purchase> purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        // Get all purchases with pagination
        public async Task<IEnumerable<Purchase>> GetPagedPurchasesAsync(int pageNumber, int pageSize)
        {
            return await _purchaseRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get a purchase by ID
        public async Task<Purchase> GetPurchaseByIdAsync(int id)
        {
            return await _purchaseRepository.GetByIdAsync(id);
        }

        // Create a new purchase
        public async Task CreatePurchaseAsync(Purchase purchase)
        {
            await _purchaseRepository.CreateAsync(purchase);
        }

        // Update an existing purchase
        public async Task UpdatePurchaseAsync(Purchase purchase)
        {
            var existingPurchase = await _purchaseRepository.GetByIdAsync(purchase.PurchaseId);
            if (existingPurchase == null) 
            {
                throw new InvalidOperationException("Purchase Not Found");
            }
            existingPurchase.PurchaseDate = purchase.PurchaseDate;
            existingPurchase.TvaAmount = purchase.TvaAmount;
            existingPurchase.TotalAmount = purchase.TotalAmount;
            existingPurchase.AmountPaid = purchase.AmountPaid;
            //existingPurchase.OutstandingBalance = purchase.TotalAmount - purchase.AmountPaid;
            existingPurchase.SupplierId = purchase.SupplierId;
            existingPurchase.EmployeeId = purchase.EmployeeId;

            await _purchaseRepository.UpdateAsync(existingPurchase);
        }

        // Delete a purchase by ID
        public async Task DeletePurchaseAsync(int id)
        {
            await _purchaseRepository.DeleteAsync(id);
        }

        public async Task<int> CountPurchasesAsync()
        {
            return await _purchaseRepository.CountAsync();
        }
    }
}
