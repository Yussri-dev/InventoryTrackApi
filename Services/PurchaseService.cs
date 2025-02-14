using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class PurchaseService
    {
        private readonly IGenericRepository<Purchase> _purchaseRepository;
        private readonly IGenericRepository<Supplier> _supplierRepository;
        private readonly IMapper _mapper;

        // Constructor to inject the repository
        public PurchaseService(IGenericRepository<Purchase> purchaseRepository,
            IGenericRepository<Supplier> supplierRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
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


        public async Task<IEnumerable<PurchaseDTO>> GetPagedPurchasesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (Purchase)
            Expression<Func<Purchase, bool>> dateFilter = Purchase =>
                Purchase.DateCreated.Date >= startDate.Date && Purchase.DateCreated.Date <= endDate.Date;

            // Fetch Purchases with customer names
            var Purchases = await _purchaseRepository.GetByConditionAsync(dateFilter, "Supplier");

            // Map to DTO using AutoMapper
            var PurchaseDTOs = _mapper.Map<IEnumerable<PurchaseDTO>>(Purchases);

            return PurchaseDTOs;
        }

        //public async Task<IEnumerable<PurchaseDTO>> GetPagedPurchasesByDateRangeAsync(DateTime startDate, DateTime endDate)
        //{
        //    // Define the filter using the entity type (SaleItem)
        //    Expression<Func<Purchase, bool>> dateFilter = saleItem =>
        //        saleItem.DateCreated.Date >= startDate.Date && saleItem.DateCreated.Date <= endDate.Date;

        //    // Fetch SaleItem entities from the repository
        //    var purchases = await _purchaseRepository.GetByConditionAsync(dateFilter);

        //    // Fetch Product entities for the SaleItems
        //    var supplierIds = purchases.Select(s => s.SupplierId).Distinct();
        //    var suppliers = await _supplierRepository.GetByConditionAsync(p => supplierIds.Contains(p.SupplierId));

        //    // Create a dictionary for quick lookup of Product by ProductId
        //    var customerDictionary = suppliers.ToDictionary(p => p.SupplierId, p => p);

        //    // Map SaleItem entities to SaleItemDTO objects
        //    var purchaseDTOs = purchases.Select(s => new PurchaseDTO
        //    {
        //        PurchaseId = s.PurchaseId,
        //        SupplierId = s.SupplierId,
        //        SupplierName = customerDictionary.TryGetValue(s.SupplierId, out var supplier) ? supplier.Name : null, // Get ProductName from the dictionary
        //        TvaAmount = s.TvaAmount,
        //        TotalAmount = s.TotalAmount,
        //        AmountPaid = s.AmountPaid,
        //        PurchaseDate = s.DateCreated
        //    });

        //    return purchaseDTOs;
        //}

    }
}
