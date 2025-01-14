using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class PurchasePaymentService
    {
        private readonly IGenericRepository<PurchasePayment> _purchasePaymentRepository;

        // Constructor to inject the repository
        public PurchasePaymentService(IGenericRepository<PurchasePayment> purchasePaymentRepository)
        {
            _purchasePaymentRepository = purchasePaymentRepository;
        }
        // Get all purchasePayments with pagination
        public async Task<IEnumerable<PurchasePayment>> GetPagedPurchasePaymentsAsync(int pageNumber, int pageSize)
        {
            return await _purchasePaymentRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get a purchasePayment by ID
        public async Task<PurchasePayment> GetPurchasePaymentByIdAsync(int id)
        {
            return await _purchasePaymentRepository.GetByIdAsync(id);
        }

        // Create a new purchasePayment
        public async Task CreatePurchasePaymentAsync(PurchasePayment purchasePayment)
        {
            await _purchasePaymentRepository.CreateAsync(purchasePayment);
        }

        // Update an existing purchasePayment
        public async Task UpdatePurchasePaymentAsync(PurchasePayment purchasePayment)
        {
            var existingPurchasePayment = await _purchasePaymentRepository.GetByIdAsync(purchasePayment.PurchasePaymentId);
            if (existingPurchasePayment == null) 
            {
                throw new InvalidOperationException("Purchase Payment Not Found");
            }
            existingPurchasePayment.PurchaseId = purchasePayment.PurchasePaymentId;
            existingPurchasePayment.PaymentDate = purchasePayment.PaymentDate;
            existingPurchasePayment.Amount = purchasePayment.Amount;
            existingPurchasePayment.PaymentType = purchasePayment.PaymentType;

            await _purchasePaymentRepository.UpdateAsync(existingPurchasePayment);
        }

        // Delete a purchasePayment by ID
        public async Task DeletePurchasePaymentAsync(int id)
        {
            await _purchasePaymentRepository.DeleteAsync(id);
        }
    }
}
