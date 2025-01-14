using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class CustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;

        public CustomerService(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Get All Customers
        public async Task<IEnumerable<Customer>> GetPagedCustomersAsync(int pageNumber, int pageSize)
        {
            return await _customerRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get a Customer by Id
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        //Create a new Customer
        public async Task CreateCustomerAsync(Customer customer)
        {
            await _customerRepository.CreateAsync(customer);
        }

        //Update a Customer
        public async Task UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(customer.CustomerId);

            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not Found.");
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.CreditLimit = customer.CreditLimit;
            existingCustomer.AccountBalance = customer.AccountBalance;
            existingCustomer.PhoneNumber1 = customer.PhoneNumber1;
            existingCustomer.PhoneNumber2 = customer.PhoneNumber2;
            existingCustomer.Email = customer.Email;
            existingCustomer.Adresse = customer.Adresse;
            existingCustomer.City = customer.City;
            existingCustomer.Land = customer.Land;
            existingCustomer.IsActivate = customer.IsActivate;

            await _customerRepository.UpdateAsync(existingCustomer);
        }

        public async Task<Customer> UpdateCustomerThresHoldAsync(int id, decimal Threshold)
        {
            var existingProduct = await _customerRepository.GetByIdAsync(id);

            if (existingProduct == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            existingProduct.CreditLimit += Threshold;

            await _customerRepository.UpdateAsync(existingProduct);

            return existingProduct; // Return the updated product.
        }


        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        //Get a Customer by Name
        public async Task<IEnumerable<Customer>> GetCustomerByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _customerRepository.GetByNameAsync(p => p.Name.Contains(name));
        }

    }
}
