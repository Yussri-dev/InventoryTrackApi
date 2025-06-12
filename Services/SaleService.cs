using AutoMapper;
using InventoryTrackApi.Data;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Queries;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace InventoryTrackApi.Services
{
    public class SaleService
    {
        private readonly IMapper _mapper;
        private readonly DiscountCalculator _discountCalculator;
        private readonly IUnitOfWork _unitOfWork;
        public SaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<SaleFlatDTO>> GetAllSaleFlatAsync(string userId, DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (Purchase)
            Expression<Func<Sale, bool>> dateFilter = purchase =>
            purchase.UserId == userId &&
                purchase.SaleDate >= startDate.Date && purchase.SaleDate < endDate.Date.AddDays(1);

            //var purchases = await _saleRepository.GetDataByDateRange(dateFilter);
            var purchases = await _unitOfWork.Sales.GetDataByDateRange(dateFilter);
            var result = new List<SaleFlatDTO>();

            foreach (var purchase in purchases)
            {
                //var purchaseItems = await _saleItemRepository.GetByConditionAsync(pi => pi.SaleId == purchase.SaleId
                var purchaseItems = await _unitOfWork.SaleItems.GetByConditionAsync(pi => pi.SaleId == purchase.SaleId

                );

                foreach (var item in purchaseItems)
                {
                    var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);

                    result.Add(new SaleFlatDTO
                    {
                        // Purchase info
                        SaleId = purchase.SaleId,
                        SaleDate = purchase.SaleDate,
                        CustomerId = purchase.CustomerId,
                        CustomerName = purchase.Customer?.Name,
                        //UserId = purchase.UserId,
                        //TvaAmount = purchase.TvaAmount,
                        //TotalAmount = purchase.TotalAmount,
                        //AmountPaid = purchase.AmountPaid,

                        // Item info
                        //PurchaseItemId = item.PurchaseItemId,
                        SaleItemId = item.SaleItemId,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        Discount = item.Discount,
                        TaxAmount = item.TaxAmount,

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
        public async Task<List<SaleFlatDTO>> GetAllSaleFlatAsync(DateTime startDate, DateTime endDate)
        {
            // Define the filter using the entity type (Purchase)
            Expression<Func<Sale, bool>> dateFilter = purchase =>
                purchase.SaleDate >= startDate.Date && purchase.SaleDate < endDate.Date.AddDays(1);

            //var purchases = await _saleRepository.GetDataByDateRange(dateFilter);
            var purchases = await _unitOfWork.Sales.GetDataByDateRange(dateFilter);
            var result = new List<SaleFlatDTO>();

            foreach (var purchase in purchases)
            {
                //var purchaseItems = await _saleItemRepository.GetByConditionAsync(pi => pi.SaleId == purchase.SaleId
                var purchaseItems = await _unitOfWork.SaleItems.GetByConditionAsync(pi => pi.SaleId == purchase.SaleId

                );

                foreach (var item in purchaseItems)
                {
                    var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);

                    result.Add(new SaleFlatDTO
                    {
                        // Purchase info
                        SaleId = purchase.SaleId,
                        SaleDate = purchase.SaleDate,
                        CustomerId = purchase.CustomerId,
                        CustomerName = purchase.Customer?.Name,
                        //UserId = purchase.UserId,
                        //TvaAmount = purchase.TvaAmount,
                        //TotalAmount = purchase.TotalAmount,
                        //AmountPaid = purchase.AmountPaid,

                        // Item info
                        //PurchaseItemId = item.PurchaseItemId,
                        SaleItemId = item.SaleItemId,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        Discount = item.Discount,
                        TaxAmount = item.TaxAmount,

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

        public async Task<int> CountSalesAsync()
        {
            return await _unitOfWork.Sales.CountAsync();
        }

        // Get all sales with pagination
        public async Task<IEnumerable<Sale>> GetPagedSalesAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Sales.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<IEnumerable<MonthlySummaryDTO>> GetMonthlySummaryAsync(string userId, DateTime startDate, DateTime endDate)
        {
            var result = new List<MonthlySummaryDTO>();

            // Get first day of the start month
            var currentMonth = new DateTime(startDate.Year, startDate.Month, 1);

            // Get last day of the end month
            var endMonth = new DateTime(endDate.Year, endDate.Month, 1).AddMonths(1).AddDays(-1);
            //string userId = "2f9aed4c-a3db-4b32-aeac-0e30e156b180";
            //string userId = "75763e19-9fb7-4eff-bc39-a0d2a5d7a1a9";
            while (currentMonth <= endMonth)
            {
                var monthStart = currentMonth;
                var monthEnd = currentMonth.AddMonths(1).AddDays(-1);

                // Get sales data
                var salesAmount = await _unitOfWork.Sales.GetSumByPeriodAsync(
                    sale => sale.SaleDate >= monthStart && sale.SaleDate <= monthEnd && sale.UserId == userId,
                    sale => sale.TotalAmount
                );

                var salesCount = await _unitOfWork.Sales.CountAsync(
                    sale => sale.SaleDate >= monthStart && sale.SaleDate <= monthEnd && sale.UserId == userId
                );

                // Get purchase data
                var purchasesAmount = await _unitOfWork.Purchases.GetSumByPeriodAsync(
                    purchase => purchase.PurchaseDate >= monthStart && purchase.PurchaseDate <= monthEnd && purchase.UserId == userId,
                    purchase => purchase.TotalAmount
                );

                var purchasesCount = await _unitOfWork.Purchases.CountAsync(
                    purchase => purchase.PurchaseDate >= monthStart && purchase.PurchaseDate <= monthEnd && purchase.UserId == userId
                );

                // Add to result
                result.Add(new MonthlySummaryDTO
                {
                    Month = currentMonth.ToString("MMM"),
                    Year = currentMonth.Year,
                    MonthYear = currentMonth.ToString("MMM yyyy"),
                    SalesAmount = salesAmount,
                    PurchasesAmount = purchasesAmount,
                    SalesCount = salesCount,
                    PurchasesCount = purchasesCount
                });

                // Move to next month
                currentMonth = currentMonth.AddMonths(1);
            }

            return result;
        }

        //Get Sum Sales
        public async Task<decimal> GetSumByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.Sales.GetSumByPeriodAsync(
                sale => sale.SaleDate >= startDate && sale.SaleDate <= endDate,
                sale => sale.TotalAmount
            );
        }

        // Get a sale by ID
        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _unitOfWork.Sales.GetByIdAsync(id);
        }

        public async Task CreateSaleAsync(Sale sale, string typeSale, int cashRegisterId)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _unitOfWork.Sales.CreateAsync(sale);

                var salePayment = new SalePayment
                {
                    SaleId = sale.SaleId,
                    Amount = sale.TotalAmount,
                    PaymentDate = sale.SaleDate,
                    PaymentType = typeSale,
                    SaasClientId = sale.SaasClientId
                };
                await _unitOfWork.SalePayments.CreateAsync(salePayment);

                var activeCashShifts = await _unitOfWork.CashShifts.GetWhereAsync(cs =>
                    cs.CashRegisterId == cashRegisterId &&
                    cs.SaasClientId == sale.SaasClientId &&
                    cs.ShiftEnd == null);

                var activeCashShift = activeCashShifts.FirstOrDefault();

                if (activeCashShift == null)
                {
                    throw new InvalidOperationException("No active cash shift found for the register.");
                }

                activeCashShift.CashIn += sale.TotalAmount;
                activeCashShift.TotalSales += sale.TotalAmount;

                await _unitOfWork.CashShifts.UpdateAsync(activeCashShift);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        // Update an existing sale
        public async Task UpdateSaleAsync(Sale sale)
        {
            var existingSale = await _unitOfWork.Sales.GetByIdAsync(sale.SaleId);

            if (existingSale == null)
            {
                throw new InvalidOperationException("Sale Not Found");
            }

            existingSale.SaleDate = sale.SaleDate;
            existingSale.CustomerId = sale.CustomerId;
            existingSale.UserId = sale.UserId;
            existingSale.TvaAmount = sale.TvaAmount;
            existingSale.TotalAmount = sale.TotalAmount;
            existingSale.AmountPaid = sale.AmountPaid;

            await _unitOfWork.Sales.UpdateAsync(existingSale);
        }

        // Delete a sale by ID
        public async Task DeleteSaleAsync(int id)
        {
            await _unitOfWork.Sales.DeleteAsync(id);
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

            var sales = await _unitOfWork.Sales.GetByConditionAsync(dateFilter, "Customer");

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

            await _unitOfWork.Sales.SaveChangesAsync();

            Console.WriteLine($"Remaining payment after distribution: {remainingPayment}");
        }

        private async Task<List<Sale>> GetOutstandingSalesAsync(int customerId)
        {
            Expression<Func<Sale, bool>> customerIdFilter = sale =>
                sale.CustomerId == customerId && sale.TotalAmount > sale.AmountPaid;

            var outstandingSales = await _unitOfWork.Sales.GetByConditionAsync(customerIdFilter, "Customer");

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

            var sales = await _unitOfWork.Sales.GetByConditionAsync(customerIdFilter, "Customer");

            var saleDTOs = _mapper.Map<IEnumerable<SaleDTO>>(sales);

            return saleDTOs;
        }

    }
}
