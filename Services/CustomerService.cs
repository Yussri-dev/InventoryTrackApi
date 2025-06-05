using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class CustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private const string validating = "Yes";

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Customer>> GetPagedCustomersAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Customers.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(int saasClientId)
        {
            Expression<Func<Customer, bool>> filter = c => c.SaasClientId == saasClientId;
            return await _unitOfWork.Customers.GetByConditionAsync(filter);
        }

        public async Task<int> CountCustomersAsync()
        {
            return await _unitOfWork.Customers.CountAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _unitOfWork.Customers.GetByIdAsync(id);
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                bool exists = await _unitOfWork.Customers.ExistsAsync(p => p.Name == customer.Name);

                if (exists)
                {
                    throw new InvalidOperationException("Customer with the same Rate already exists.");
                }

                await _unitOfWork.Customers.CreateAsync(customer);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            }

            var existingCustomer = await _unitOfWork.Customers.GetByIdAsync(customer.CustomerId);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            _mapper.Map(customer, existingCustomer);
            await _unitOfWork.Customers.UpdateAsync(existingCustomer);
        }

        public async Task<Customer> UpdateCustomerThresHoldAsync(int id, decimal amount, decimal amountPaid, string validate)
        {
            var existingCustomer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            if (id != existingCustomer.CustomerId && validate == validating)
            {
                existingCustomer.CreditLimit += amount;
                existingCustomer.AccountBalance += amount;
                existingCustomer.AmountPaid += amountPaid;
            }

            await _unitOfWork.Customers.UpdateAsync(existingCustomer);
            return existingCustomer;
        }

        public async Task<Customer> UpdateAccountBalanceAsync(int id, decimal amount)
        {
            if (amount == 0)
            {
                throw new ArgumentException("Amount must be non-zero.", nameof(amount));
            }

            var existingCustomer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            if (id != existingCustomer.CustomerId)
            {
                existingCustomer.AmountPaid += amount;
            }

            await _unitOfWork.Customers.UpdateAsync(existingCustomer);
            return existingCustomer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _unitOfWork.Customers.DeleteAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomerByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            Expression<Func<Customer, bool>> nameFilter = customer =>
                EF.Functions.Like(customer.Name, $"%{name}%");

            return await _unitOfWork.Customers.GetByConditionAsync(nameFilter);
        }

        public async Task<IEnumerable<CustomerDTO>> GetSpecificCustomersAsync()
        {
            Expression<Func<Customer, bool>>
                customerIdFilter = customer
                => (customer.AccountBalance - customer.AmountPaid) != 0;

            var customers = await _unitOfWork.Customers.GetByConditionAsync(customerIdFilter);
            var customerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return customerDTOs;
        }
    }
}