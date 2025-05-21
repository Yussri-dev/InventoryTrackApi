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
        private readonly IGenericRepository<PurchaseItem> _purchaseItemRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        // Constructor to inject the repository
        public PurchaseService(
            IGenericRepository<Purchase> purchaseRepository,
            IGenericRepository<Supplier> supplierRepository,
            IGenericRepository<PurchaseItem> purchaseItemRepository,
            IGenericRepository<Product> productRepository,
            IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _purchaseItemRepository = purchaseItemRepository;
            _mapper = mapper;
        }
        // Get all purchases with pagination
        public async Task<IEnumerable<Purchase>> GetPagedPurchasesAsync(int pageNumber, int pageSize)
        {
            return await _purchaseRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get Sum Purchase
        public async Task<decimal> GetSumByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            return await _purchaseRepository.GetSumByPeriodAsync(
                sale => sale.PurchaseDate >= startDate && sale.PurchaseDate <= endDate,
                sale => sale.TotalAmount
            );
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
           
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase), "Purchase cannot be null");
            }

            var existingPurchase = await _purchaseRepository.GetByIdAsync(purchase.PurchaseId);

            if (existingPurchase == null) 
            {
                throw new InvalidOperationException("Purchase Not Found");
            }

            //_mapper.Map(purchase, existingPurchase);
            existingPurchase.PurchaseDate = purchase.PurchaseDate;
            existingPurchase.TvaAmount = purchase.TvaAmount;
            existingPurchase.TotalAmount = purchase.TotalAmount;
            existingPurchase.AmountPaid = purchase.AmountPaid;
            //existingPurchase.OutstandingBalance = purchase.TotalAmount - purchase.AmountPaid;
            existingPurchase.SupplierId = purchase.SupplierId;
            existingPurchase.EmployeeId = purchase.EmployeeId;
            existingPurchase.SaasClientId = purchase.SaasClientId;

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

        public async Task<List<PurchaseFlatDTO>> GetAllPurchaseFlatAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            var result = new List<PurchaseFlatDTO>();

            foreach (var purchase in purchases)
            {
                var purchaseItems = await _purchaseItemRepository.GetByConditionAsync(
                    pi => pi.PurchaseId == purchase.PurchaseId
                );

                foreach (var item in purchaseItems)
                {
                    var product = await _productRepository.GetByIdAsync(item.ProductId);

                    result.Add(new PurchaseFlatDTO
                    {
                        // Purchase info
                        PurchaseId = purchase.PurchaseId,
                        PurchaseDate = purchase.PurchaseDate,
                        SupplierId = purchase.SupplierId,
                        SupplierName = purchase.Supplier?.Name,
                        //EmployeeId = purchase.EmployeeId,
                        //TvaAmount = purchase.TvaAmount,
                        //TotalAmount = purchase.TotalAmount,
                        //AmountPaid = purchase.AmountPaid,

                        // Item info
                        //PurchaseItemId = item.PurchaseItemId,
                        PurchaseItemId = item.PurchaseItemId,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        Discount = item.Discount,
                        TaxAmount = item.TaxAmount,
                        LineTotal = item.Total,

                        // Product info
                        ProductId = product.ProductId,
                        ProductName = product.Name,
                        PurchasePrice = product.PurchasePrice,
                        SalePrice1 = product.SalePrice1,
                        SalePrice2 = product.SalePrice2,
                        SalePrice3 = product.SalePrice3,
                        Barcode = product.Barcode,
                        QuantityStock = product.QuantityStock,
                        QuantityPack = product.QuantityPack
                    });
                }
            }

            return result;
        }

        //public async Task<List<PurchaseDetailDTO>> GetPurchaseDetailsAsync()
        //{
        //    var purchases = await _purchaseRepository.GetAllAsync();

        //    var purchaseDetails = new List<PurchaseDetailDTO>();

        //    foreach (var purchase in purchases)
        //    {
        //        var purchaseItems = await _purchaseItemRepository.GetByConditionAsync(
        //            pi => pi.PurchaseId == purchase.PurchaseId
        //        );

        //        var itemWithProducts = new List<PurchaseItemWithProductDTO>();

        //        foreach (var item in purchaseItems)
        //        {
        //            var product = await _productRepository.GetByIdAsync(item.ProductId);

        //            itemWithProducts.Add(new PurchaseItemWithProductDTO
        //            {
        //                PurchaseItem = new PurchaseItemDTO
        //                {
        //                    PurchaseItemId = item.PurchaseItemId,
        //                    PurchaseId = item.PurchaseId,
        //                    ProductId = item.ProductId,
        //                    Quantity = item.Quantity,
        //                    Price = item.Price,
        //                    Discount = item.Discount,
        //                    TaxAmount = item.TaxAmount,
        //                    Total = item.Total,
        //                    ProductName = item.Product.Name,
        //                    DateCreated = item.DateCreated,
        //                    SaasClientId = item.SaasClientId
        //                },
        //                Product = new ProductDTO
        //                {
        //                    ProductId = product.ProductId,
        //                    Name = product.Name,
        //                    PurchasePrice = product.PurchasePrice,
        //                    SalePrice1 = product.SalePrice1,
        //                    SalePrice2 = product.SalePrice2,
        //                    SalePrice3 = product.SalePrice3,
        //                    Barcode = product.Barcode,
        //                    QuantityStock = product.QuantityStock,
        //                    QuantityPack = product.QuantityPack
        //                }
        //            });
        //        }

        //        purchaseDetails.Add(new PurchaseDetailDTO
        //        {
        //            Purchase = new PurchaseDTO
        //            {
        //                PurchaseId = purchase.PurchaseId,
        //                PurchaseDate = purchase.PurchaseDate,
        //                SupplierId = purchase.SupplierId,
        //                EmployeeId = purchase.EmployeeId,
        //                TvaAmount = purchase.TvaAmount,
        //                TotalAmount = purchase.TotalAmount,
        //                AmountPaid = purchase.AmountPaid,
        //                SupplierName = purchase.Supplier?.Name,
        //                SaasClientId = purchase.SaasClientId
        //            },
        //            Items = itemWithProducts
        //        });
        //    }

        //    return purchaseDetails;
        //}

        //public async Task<PurchaseDetailDTO> GetPurchaseDetailAsync(int purchaseId)
        //{
        //    var purchase = await _purchaseRepository.GetByIdAsync(purchaseId);

        //    var purchaseItems = await _purchaseItemRepository.GetByConditionAsync(
        //        pi => pi.PurchaseId == purchaseId
        //    );

        //    var itemWithProducts = new List<PurchaseItemWithProductDTO>();

        //    foreach (var item in purchaseItems)
        //    {
        //        var product = await _productRepository.GetByIdAsync(item.ProductId);

        //        itemWithProducts.Add(new PurchaseItemWithProductDTO
        //        {
        //            PurchaseItem = new PurchaseItemDTO
        //            {
        //                PurchaseItemId = item.PurchaseItemId,
        //                PurchaseId = item.PurchaseId,
        //                ProductId = item.ProductId,
        //                Quantity = item.Quantity,
        //                Price = item.Price,
        //                Discount = item.Discount,
        //                TaxAmount = item.TaxAmount,
        //                Total = item.Total,
        //                ProductName = item.Product.Name,
        //                DateCreated = item.DateCreated,
        //                SaasClientId = item.SaasClientId
        //            },
        //            Product = new ProductDTO
        //            {
        //                ProductId = product.ProductId,
        //                Name = product.Name,
        //                PurchasePrice = product.PurchasePrice,
        //                SalePrice1 = product.SalePrice1,
        //                SalePrice2 = product.SalePrice2,
        //                SalePrice3 = product.SalePrice3,
        //                Barcode = product.Barcode,
        //                QuantityStock = product.QuantityStock,
        //                QuantityPack = product.QuantityPack,
        //            }
        //        });
        //    }

        //    return new PurchaseDetailDTO
        //    {
        //        Purchase = new PurchaseDTO
        //        {
        //            PurchaseId = purchase.PurchaseId,
        //            PurchaseDate = purchase.PurchaseDate,
        //            SupplierId = purchase.SupplierId,
        //            EmployeeId = purchase.EmployeeId,
        //            TvaAmount = purchase.TvaAmount,
        //            TotalAmount = purchase.TotalAmount,
        //            AmountPaid = purchase.AmountPaid,
        //            SupplierName = purchase.Supplier.Name,
        //            SaasClientId = purchase.SaasClientId
        //        },
        //        Items = itemWithProducts
        //    };
        //}

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
