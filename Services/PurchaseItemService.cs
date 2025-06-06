﻿using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class PurchaseItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PurchaseItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // Get all purchaseItems with pagination
        public async Task<IEnumerable<PurchaseItem>> GetPagedPurchaseItemsAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.PurchaseItems.GetAllAsync(pageNumber, pageSize);
        }

        // Get a purchaseItem by ID
        public async Task<PurchaseItem> GetPurchaseItemByIdAsync(int id)
        {
            return await _unitOfWork.PurchaseItems.GetByIdAsync(id);
        }


        // Create a new purchaseItem
        public async Task CreatePurchaseItemAsync(PurchaseItem purchaseItem)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(purchaseItem.ProductId);
                if (product == null)
                {
                    throw new InvalidOperationException("Product not Found");
                }
                product.QuantityStock += purchaseItem.Quantity;
                await _unitOfWork.Products.UpdateAsync(product);
                await _unitOfWork.PurchaseItems.CreateAsync(purchaseItem);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        // Update an existing purchaseItem
        public async Task UpdatePurchaseItemAsync(PurchaseItem purchaseItem)
        {
            var existingPurchaseItem = await _unitOfWork.PurchaseItems.GetByIdAsync(purchaseItem.PurchaseItemId);

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

            await _unitOfWork.PurchaseItems.UpdateAsync(existingPurchaseItem);

        }

        // Delete a purchaseItem by ID
        public async Task DeletePurchaseItemAsync(int id)
        {
            await _unitOfWork.PurchaseItems.DeleteAsync(id);
        }

        public async Task<IEnumerable<PurchaseItemDTO>> GetPagedPurchaseItemsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (purchaseItem)
            Expression<Func<PurchaseItem, bool>> dateFilter = purchaseItem =>
                purchaseItem.DateCreated.Date >= startDate.Date && purchaseItem.DateCreated.Date <= endDate.Date;

            // Fetch sales with customer names
            var purchaseItems = await _unitOfWork.PurchaseItems.GetByConditionAsync(dateFilter, "Product");

            // Map to DTO using AutoMapper
            var purchaseItemDTOs = _mapper.Map<IEnumerable<PurchaseItemDTO>>(purchaseItems);

            return purchaseItemDTOs;
        }
    }
}
