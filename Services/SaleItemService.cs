using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Queries;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace InventoryTrackApi.Services
{
    public class SaleItemService
    {
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SaleItemService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
            _mapper = mapper;
        }
        // Get all saleItems with pagination
        public async Task<IEnumerable<SaleItem>> GetPagedSaleItemsAsync(int pageNumber, int pageSize)
        {
            string cacheSaleItems = $"SaleItems_{pageNumber}_{pageSize}";
            return await _cacheService.GetOrAddAsync(cacheSaleItems, async () =>
            {
                return await _unitOfWork.SaleItems.GetAllAsync(pageNumber, pageSize);

            });
        }

        public async Task<IEnumerable<SaleItemDTO>> GetPagedSaleItemsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            string cacheKey = $"SaleItems_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}";

            return await _cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                Expression<Func<SaleItem, bool>> dateFilter = saleItem =>
               saleItem.DateCreated.Date >= startDate.Date && saleItem.DateCreated.Date <= endDate.Date;

                // Fetch SaleItem entities from the repository
                var saleItems = await _unitOfWork.SaleItems.GetByConditionAsync(dateFilter);

                // Fetch Product entities for the SaleItems
                var productIds = saleItems.Select(s => s.ProductId).Distinct();
                var products = await _unitOfWork.Products.GetByConditionAsync(p => productIds.Contains(p.ProductId));

                // Create a dictionary for quick lookup of Product by ProductId
                var productDictionary = products.ToDictionary(p => p.ProductId, p => p);

                // Map SaleItem entities to SaleItemDTO objects
                var saleItemDTOs = saleItems.Select(s => new SaleItemDTO
                {
                    SaleItemId = s.SaleItemId,
                    SaleId = s.SaleId,
                    ProductId = s.ProductId,
                    ProductName = productDictionary.TryGetValue(s.ProductId, out var product) ? product.Name : null, // Get ProductName from the dictionary
                    Quantity = s.Quantity,
                    Price = s.Price,
                    ProfitMarge = s.ProfitMarge,
                    PurchasePrice = s.PurchasePrice,
                    Discount = s.Discount,
                    TaxAmount = s.TaxAmount,
                    Total = s.Total,
                    DateCreated = s.DateCreated
                });

                return saleItemDTOs;
            });

        }

        public async Task<decimal> CalculateProfitsAsync(DateTime startDate)
        {
            Expression<Func<SaleItem, decimal>> profitSelector = saleItem => saleItem.ProfitMarge;
            Expression<Func<SaleItem, bool>> dateFilter = saleItem => saleItem.DateCreated.Date.Equals(startDate.Date);
            //&& saleItem.DateCreated <= endDate;

            return await _unitOfWork.SaleItems.CalculateSumAsync(dateFilter, profitSelector);
        }

        // Get a saleItem by ID
        public async Task<SaleItem> GetSaleItemByIdAsync(int id)
        {
            return await _unitOfWork.SaleItems.GetByIdAsync(id);
        }

        // Create a new saleItem
        //decimal paymentAmount, string paymentType, int saasClientId
        //public async Task CreateSaleItemAsync(SaleItem saleItem, decimal paymentAmount, string paymentType, int saasClientId)
        //{
        //    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //    {
        //        var product = await _unitOfWork.Products.GetByIdAsync(saleItem.ProductId);

        //        if (product == null)
        //            throw new InvalidOperationException("Product not found");

        //        if (product.QuantityStock < saleItem.Quantity)
        //            throw new InvalidOperationException("Insufficient stock");

        //        // Update product stock
        //        product.QuantityStock -= saleItem.Quantity;
        //        await _unitOfWork.Products.UpdateAsync(product);

        //        // Create sale item
        //        await _unitOfWork.SaleItems.CreateAsync(saleItem);

        //        // Create sale payment
        //        var salePayment = new SalePayment
        //        {
        //            SaleId = saleItem.SaleId,
        //            Amount = saleItem.Total,
        //            PaymentType = "Cash",
        //            SaasClientId = saleItem.SaasClientId
        //        };
        //        await _salePaymentRepository.CreateAsync(salePayment);

        //        // Clear relevant cache
        //        _cacheService.Remove($"SaleItems_{DateTime.Today:yyyyMMdd}_{DateTime.Today:yyyyMMdd}");

        //        // Commit transaction
        //        scope.Complete();
        //    }
        //}

        public async Task CreateSaleItemAsync(SaleItem saleItem)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(saleItem.ProductId);

                if (product == null)
                {
                    throw new InvalidOperationException("Product Not Found");
                }
                if (product.QuantityStock < saleItem.Quantity)
                {
                    throw new InvalidOperationException("Insuffisant stock");
                }
                product.QuantityStock -= saleItem.Quantity;
                await _unitOfWork.Products.UpdateAsync(product);
                await _unitOfWork.SaleItems.CreateAsync(saleItem);

                await _unitOfWork.CommitAsync();
                _cacheService.Remove($"SaleItems_{DateTime.Today:yyyyMMdd}_{DateTime.Today:yyyyMMdd}");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

        }

        // Update an existing saleItem
        public async Task UpdateSaleItemAsync(SaleItem saleItem)
        {
            var existingSaleItem = await _unitOfWork.SaleItems.GetByIdAsync(saleItem.SaleItemId);

            if (existingSaleItem == null)
            {
                throw new InvalidOperationException("Sale Item Not Found");
            }

            existingSaleItem.SaleId = saleItem.SaleItemId;
            existingSaleItem.Quantity = saleItem.Quantity;
            existingSaleItem.Price = saleItem.Price;
            existingSaleItem.Discount = saleItem.Discount;
            existingSaleItem.TaxAmount = saleItem.TaxAmount;
            existingSaleItem.Total = saleItem.Total;
            existingSaleItem.SaasClientId = saleItem.SaasClientId;

            await _unitOfWork.SaleItems.UpdateAsync(existingSaleItem);
        }

        // Delete a saleItem by ID
        public async Task DeleteSaleItemAsync(int id)
        {
            await _unitOfWork.SaleItems.DeleteAsync(id);
        }

        // Get all saleItems with pagination
        public async Task<IEnumerable<SaleItemDTO>> GetPagedSaleItemsByIdAsync(int idCode)
        {
            // Fetch sale items by barcode or ID
            var saleItems = await _unitOfWork.SaleItems.GetByBarCodeAsync(p => p.SaleId.Equals(idCode));

            // Get product IDs from the fetched sale items
            var productIds = saleItems.Select(s => s.ProductId).ToList();

            // Fetch product data
            var products = await _unitOfWork.Products.GetAllAsync();
            var productMap = products.ToDictionary(p => p.ProductId);

            // Combine SaleItem and Product into SaleItemDTO
            var saleItemDtoList = saleItems.Select(saleItem =>
            {
                var product = productMap.ContainsKey(saleItem.ProductId) ? productMap[saleItem.ProductId] : null;

                return new SaleItemDTO
                {
                    SaleItemId = saleItem.SaleItemId,
                    SaleId = saleItem.SaleId,
                    ProductId = saleItem.ProductId,
                    Quantity = saleItem.Quantity,
                    Price = saleItem.Price,
                    Discount = saleItem.Discount,
                    TaxAmount = saleItem.TaxAmount,
                    Total = saleItem.Total,
                    ProductName = product?.Name ?? "Unknown", // Add ProductName
                };
            });

            return saleItemDtoList;
        }

        public async Task<IEnumerable<SaleItemDTO>> GetSaleItemsWithProductAsync(int pageNumber, int pageSize)
        {
            var saleItems = await _unitOfWork.SaleItems.GetAllAsync(pageNumber, pageSize);

            // Get product IDs from sale items
            var productIds = saleItems.Select(s => s.ProductId).ToList();

            // Fetch product data
            var products = await _unitOfWork.Products.GetAllAsync();
            var productMap = products.ToDictionary(p => p.ProductId);

            // Combine SaleItem and Product into SaleItemWithProductDTO
            var saleItemWithProductList = saleItems.Select(saleItem =>
            {
                var product = productMap.ContainsKey(saleItem.ProductId) ? productMap[saleItem.ProductId] : null;

                return new SaleItemDTO
                {
                    SaleItemId = saleItem.SaleItemId,
                    SaleId = saleItem.SaleId,
                    ProductId = saleItem.ProductId,
                    Quantity = saleItem.Quantity,
                    Price = saleItem.Price,
                    Discount = saleItem.Discount,
                    TaxAmount = saleItem.TaxAmount,
                    Total = saleItem.Total,
                    ProductName = product?.Name ?? "Unknown",
                };
            });

            return saleItemWithProductList;
        }

        public async Task<IEnumerable<SaleItemDTO>> GetSalesItemByIdAsync(int saleId)
        {
            // Define the filter using the entity type (SaleItem)
            Expression<Func<SaleItem, bool>> saleIdFilter = saleItem => saleItem.SaleId == saleId;

            // Fetch sale items with related Sale and Product entities
            var saleItems = await _unitOfWork.SaleItems.GetByConditionAsync(
                filter: saleIdFilter,
                includeProperties: "Product" // Correct navigation properties
            );

            // Map to DTO using AutoMapper
            var saleItemsDTOs = _mapper.Map<IEnumerable<SaleItemDTO>>(saleItems);

            return saleItemsDTOs;
        }
    }
}
