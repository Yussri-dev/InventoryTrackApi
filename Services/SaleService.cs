using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Queries;
using InventoryTrackApi.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class SaleService
    {
        private readonly IGenericRepository<Sale> _saleRepository;
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly DiscountCalculator _discountCalculator;
        private readonly IMapper _mapper;
        private readonly ILogger<SaleService> _logger;

        // Constructor to inject the repository
        public SaleService(IGenericRepository<Sale> saleRepository,
            IGenericRepository<Customer> customerRepository, IMapper mapper, ILogger<SaleService> logger)
        {
            _saleRepository = saleRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _discountCalculator = new DiscountCalculator();
        }

        public async Task<int> CountSalesAsync()
        {
            return await _saleRepository.CountAsync();
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

        public async Task<IEnumerable<SaleDTO>> GetPagedSalesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            Expression<Func<Sale, bool>> dateFilter = sale =>
                sale.DateCreated.Date >= startDate.Date && sale.DateCreated.Date <= endDate.Date;

            var sales = await _saleRepository.GetByConditionAsync(dateFilter, "Customer");

            var saleDTOs = _mapper.Map<IEnumerable<SaleDTO>>(sales);

            return saleDTOs;
        }

        public async Task ApplyPaymentToInvoicesAsync(int customerId, decimal paymentAmount)
        {
            var outstandingInvoices = await GetOutstandingSalesAsync(customerId);

            decimal remainingPayment = paymentAmount;

            foreach (var invoice in outstandingInvoices)
            {
                if (remainingPayment <= 0) break;

                decimal outstandingBalance = invoice.TotalAmount - invoice.AmountPaid;

                if (outstandingBalance > 0)
                {
                    decimal amountToApply = Math.Min(remainingPayment, outstandingBalance);

                    invoice.AmountPaid += amountToApply;

                    remainingPayment -= amountToApply;

                    if (invoice.AmountPaid == invoice.TotalAmount)
                    {
                        Console.WriteLine($"Invoice {invoice.SaleId} is fully paid.");
                    }
                    else
                    {
                        Console.WriteLine($"Invoice {invoice.SaleId} has been partially paid.");
                    }
                }
            }

            await _saleRepository.SaveChangesAsync(); 

            Console.WriteLine($"Remaining payment after distribution: {remainingPayment}");
        }
        
        private async Task<List<Sale>> GetOutstandingSalesAsync(int customerId)
        {
            Expression<Func<Sale, bool>> customerIdFilter = sale =>
                sale.CustomerId == customerId && sale.TotalAmount > sale.AmountPaid;

            var outstandingSales = await _saleRepository.GetByConditionAsync(customerIdFilter, "Customer");

            return outstandingSales.ToList();
        }

        /*
        public async Task ApplyPaymentToInvoiceAsync(int invoiceId, decimal paymentAmount)
        {
            if (paymentAmount <= 0)
            {
                throw new ArgumentException("Payment amount must be greater than zero.", nameof(paymentAmount));
            }

            var invoice = await _saleRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
            {
                throw new KeyNotFoundException($"Invoice with ID {invoiceId} not found.");
            }

            decimal outstandingBalance = invoice.TotalAmount - invoice.AmountPaid;
            if (outstandingBalance <= 0)
            {
                _logger.LogInformation("Invoice {InvoiceId} is already fully paid.", invoiceId);
                return;
            }

            decimal amountToApply = Math.Min(paymentAmount, outstandingBalance);

            invoice.AmountPaid += amountToApply;

            try
            {
                await _saleRepository.SaveChangesAsync();
                _logger.LogInformation("Payment of {AmountToApply} applied successfully to invoice {InvoiceId}.", amountToApply, invoiceId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save changes to the database.");
                throw;
            }
        }
        */
        public async Task<IEnumerable<SaleDTO>> GetCustomerSalesAsync(int customerId)
        {
            Expression<Func<Sale, bool>> customerIdFilter = customer =>
                customer.CustomerId == customerId && customer.TotalAmount > customer.AmountPaid;

            var sales = await _saleRepository.GetByConditionAsync(customerIdFilter, "Customer");

            var saleDTOs = _mapper.Map<IEnumerable<SaleDTO>>(sales);

            return saleDTOs;
        }
    }
}
