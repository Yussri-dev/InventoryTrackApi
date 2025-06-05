using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class SalePaymentService
    {
        //private readonly IGenericRepository<SalePayment> _unitOfWork.SalePayments;

        //// Constructor to inject the repository
        //public SalePaymentService(IGenericRepository<SalePayment> salePaymentRepository)
        //{
        //    _unitOfWork.SalePayments = salePaymentRepository;
        //}
        private readonly IUnitOfWork _unitOfWork;
        public SalePaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // Get all salePayments with pagination
        public async Task<IEnumerable<SalePayment>> GetPagedSalePaymentAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.SalePayments.GetAllAsync(pageNumber, pageSize);
        }

        //get paged salePayment 
        public async Task<IEnumerable<SalePaymentDTO>> GetPagedSalePaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (SalePayment)
            Expression<Func<SalePayment, bool>> dateFilter = SalePayment =>
                SalePayment.DateCreated.Date >= startDate.Date && SalePayment.DateCreated.Date <= endDate.Date;

            // Fetch SalePayment entities from the repository
            var SalePayments = await _unitOfWork.SalePayments.GetByConditionAsync(dateFilter);

            // Fetch Product entities for the SalePayments
            var productIds = SalePayments.Select(s => s.SaleId).Distinct();
            var products = await _unitOfWork.SalePayments.GetByConditionAsync(p => productIds.Contains(p.SaleId));

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
            return await _unitOfWork.SalePayments.GetByIdAsync(id);
        }

        // Create a new salePayment
        public async Task CreateSalePaymentAsync(SalePayment salePayment)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.SalePayments.CreateAsync(salePayment);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        // Update an existing salePayment
        public async Task UpdateSalePaymentAsync(SalePayment salePayment)
        {
            var existingSalePayment = await _unitOfWork.SalePayments.GetByIdAsync(salePayment.SalePaymentId);

            if (existingSalePayment == null)
            {
                throw new InvalidOperationException("Sale Payment Not Found");
            }

            existingSalePayment.SaleId = salePayment.SalePaymentId;
            existingSalePayment.PaymentDate = salePayment.PaymentDate;
            existingSalePayment.Amount = salePayment.Amount;
            existingSalePayment.PaymentDate = salePayment.PaymentDate;

            await _unitOfWork.SalePayments.UpdateAsync(existingSalePayment);
        }

        // Delete a salePayment by ID
        public async Task DeleteSalePaymentAsync(int id)
        {
            await _unitOfWork.SalePayments.DeleteAsync(id);
        }
    }
}
