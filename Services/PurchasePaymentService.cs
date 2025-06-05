using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class PurchasePaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PurchasePaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // Get all purchasePayments with pagination
        public async Task<IEnumerable<PurchasePayment>> GetPagedPurchasePaymentsAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.PurchasePayments.GetAllAsync(pageNumber, pageSize);
        }

        // Get a purchasePayment by ID
        public async Task<PurchasePayment> GetPurchasePaymentByIdAsync(int id)
        {
            return await _unitOfWork.PurchasePayments.GetByIdAsync(id);
        }

        // Create a new purchasePayment
        public async Task CreatePurchasePaymentAsync(PurchasePayment purchasePayment)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.PurchasePayments.CreateAsync(purchasePayment);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        // Update an existing purchasePayment
        public async Task UpdatePurchasePaymentAsync(PurchasePayment purchasePayment)
        {
            var existingPurchasePayment = await _unitOfWork.PurchasePayments.GetByIdAsync(purchasePayment.PurchasePaymentId);
            if (existingPurchasePayment == null)
            {
                throw new InvalidOperationException("Purchase Payment Not Found");
            }
            existingPurchasePayment.PurchaseId = purchasePayment.PurchasePaymentId;
            existingPurchasePayment.PaymentDate = purchasePayment.PaymentDate;
            existingPurchasePayment.Amount = purchasePayment.Amount;
            existingPurchasePayment.PaymentType = purchasePayment.PaymentType;

            await _unitOfWork.PurchasePayments.UpdateAsync(existingPurchasePayment);
        }

        // Delete a purchasePayment by ID
        public async Task DeletePurchasePaymentAsync(int id)
        {
            await _unitOfWork.PurchasePayments.DeleteAsync(id);
        }
    }
}
