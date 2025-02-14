using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class CustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        private const int idCustomer = 1;
        private const string validating = "Yes";

        public CustomerService(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Customer>> GetPagedCustomersAsync(int pageNumber, int pageSize)
        {
            return await _customerRepository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _customerRepository.CreateAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            }

            var existingCustomer = await _customerRepository.GetByIdAsync(customer.CustomerId);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            _mapper.Map(customer, existingCustomer);
            await _customerRepository.UpdateAsync(existingCustomer);
        }

        public async Task<Customer> UpdateCustomerThresHoldAsync(int id, decimal amount, decimal amountPaid, string validate)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            if (id != idCustomer && validate == validating)
            {
                existingCustomer.CreditLimit += amount;
                existingCustomer.AccountBalance += amount;
                existingCustomer.AmountPaid += amountPaid;
            }

            await _customerRepository.UpdateAsync(existingCustomer);
            return existingCustomer;
        }

        public async Task<Customer> UpdateAccountBalanceAsync(int id, decimal amount)
        {
            if (amount == 0)
            {
                throw new ArgumentException("Amount must be non-zero.", nameof(amount));
            }

            var existingCustomer = await _customerRepository.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            if (id != idCustomer)
            {
                existingCustomer.AmountPaid += amount;
            }

            await _customerRepository.UpdateAsync(existingCustomer);
            return existingCustomer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomerByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            Expression<Func<Customer, bool>> nameFilter = customer =>
                EF.Functions.Like(customer.Name, $"%{name}%");

            return await _customerRepository.GetByConditionAsync(nameFilter);
        }

        public async Task<IEnumerable<CustomerDTO>> GetSpecificCustomersAsync()
        {
            Expression<Func<Customer, bool>> 
                customerIdFilter = customer 
                => customer.CustomerId != idCustomer 
                && (customer.AccountBalance - customer.AmountPaid) != 0;

            var customers = await _customerRepository.GetByConditionAsync(customerIdFilter);
            var customerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return customerDTOs;
        }
    }
}