using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Queries;
using InventoryTrackApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class SaleService
    {
        private readonly IGenericRepository<Sale> _saleRepository;
        private readonly DiscountCalculator _discountCalculator;
        // Constructor to inject the repository
        public SaleService(IGenericRepository<Sale> saleRepository)
        {
            _saleRepository = saleRepository;
            _discountCalculator = new DiscountCalculator();
        }

        // Get all sales with pagination
        public async Task<IEnumerable<Sale>> GetPagedSalesAsync(int pageNumber, int pageSize)
        {
            return await _saleRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get a sale by ID
        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _saleRepository.GetByIdAsync(id);
        }

        // Create a new sale
        public async Task CreateSaleAsync(Sale sale)
        {
            await _saleRepository.CreateAsync(sale);
        }

        // Update an existing sale
        public async Task UpdateSaleAsync(Sale sale)
        {
            var existingSale = await _saleRepository.GetByIdAsync(sale.SaleId);

            if (existingSale == null)
            {
                throw new InvalidOperationException("Sale Not Found");
            }

            existingSale.SaleDate = sale.SaleDate;
            existingSale.CustomerId = sale.CustomerId;
            existingSale.EmployeeId = sale.EmployeeId;
            existingSale.TvaAmount = sale.TvaAmount;
            existingSale.TotalAmount = sale.TotalAmount;
            existingSale.AmountPaid = sale.AmountPaid;

            await _saleRepository.UpdateAsync(existingSale);
        }

        // Delete a sale by ID
        public async Task DeleteSaleAsync(int id)
        {
            await _saleRepository.DeleteAsync(id);
        }

        //Making Discounts For Global Sales
        public async Task<decimal> CalculateSalesDiscountsAsync(decimal totalAmount, decimal discountPourcentage)
        {
            if (discountPourcentage < 0 || discountPourcentage > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100 % ");
            }
            return await Task.FromResult(totalAmount * (1 - (discountPourcentage / 100)));
        }

        public decimal CalculateSaleTotal(List<SaleItem> saleItems, decimal secondProductDiscountPercentage = 50)
        {
            decimal total = 0;

            foreach (var item in saleItems)
            {
                total += _discountCalculator.CalculateDiscountedPrice(item.Product, item.Quantity, secondProductDiscountPercentage);
            }

            return total;
        }

        public async Task<int> CountSalesAsync()
        {
            return await _saleRepository.CountAsync();
        }
    }
}
