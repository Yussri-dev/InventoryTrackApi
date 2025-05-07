using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using System.Linq.Expressions;

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

        //get paged salePayment 
        public async Task<IEnumerable<SalePaymentDTO>> GetPagedSalePaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (SalePayment)
            Expression<Func<SalePayment, bool>> dateFilter = SalePayment =>
                SalePayment.DateCreated.Date >= startDate.Date && SalePayment.DateCreated.Date <= endDate.Date;

            // Fetch SalePayment entities from the repository
            var SalePayments = await _salePaymentRepository.GetByConditionAsync(dateFilter);

            // Fetch Product entities for the SalePayments
            var productIds = SalePayments.Select(s => s.SaleId).Distinct();
            var products = await _salePaymentRepository.GetByConditionAsync(p => productIds.Contains(p.SaleId));

            // Create a dictionary for quick lookup of Product by ProductId
            var productDictionary = products.ToDictionary(p => p.SaleId, p => p);

            // Map SalePayment entities to SalePaymentDTO objects
            var SalePaymentDTOs = SalePayments.Select(s => new SalePaymentDTO
            {
                SalePaymentId = s.SalePaymentId,
                SaleId = s.SaleId,
                PaymentDate = s.PaymentDate,
                Amount = s.Amount,
                PaymentType = s.PaymentType,
            });

            return SalePaymentDTOs;
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
