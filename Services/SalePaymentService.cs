using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class SalePaymentService
    {
        private readonly IGenericRepository<SalePayment> _salePaymentRepository;

        // Constructor to inject the repository
        public SalePaymentService(IGenericRepository<SalePayment> salePaymentRepository)
        {
            _salePaymentRepository = salePaymentRepository;
        }
        // Get all salePayments with pagination
        public async Task<IEnumerable<SalePayment>> GetPagedSalePaymentAsync(int pageNumber, int pageSize)
        {
            return await _salePaymentRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get a salePayment by ID
        public async Task<SalePayment> GetSalePaymentByIdAsync(int id)
        {
            return await _salePaymentRepository.GetByIdAsync(id);
        }

        // Create a new salePayment
        public async Task CreateSalePaymentAsync(SalePayment salePayment)
        {
            await _salePaymentRepository.CreateAsync(salePayment);
        }

        // Update an existing salePayment
        public async Task UpdateSalePaymentAsync(SalePayment salePayment)
        {
            var existingSalePayment = await _salePaymentRepository.GetByIdAsync(salePayment.SalePaymentId);
            
            if (existingSalePayment == null)
            {
                throw new InvalidOperationException("Sale Payment Not Found");
            }

            existingSalePayment.SaleId = salePayment.SalePaymentId;
            existingSalePayment.PaymentDate = salePayment.PaymentDate;
            existingSalePayment.Amount = salePayment.Amount;
            existingSalePayment.PaymentDate = salePayment.PaymentDate;

            await _salePaymentRepository.UpdateAsync(existingSalePayment);
        }

        // Delete a salePayment by ID
        public async Task DeleteSalePaymentAsync(int id)
        {
            await _salePaymentRepository.DeleteAsync(id);
        }
    }
}
