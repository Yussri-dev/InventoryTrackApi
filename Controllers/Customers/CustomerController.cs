using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(CustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Get paged customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var customers = await _customerService.GetPagedCustomersAsync(pageNumber, pageSize);
            return Ok(customers);
        }

        // Get customer by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // Create a new customer
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var customer = new Customer
                {
                    Name = customerDto.Name,
                    CreditLimit = customerDto.CreditLimit,
                    AccountBalance = customerDto.AccountBalance,
                    PhoneNumber1 = customerDto.PhoneNumber1,
                    PhoneNumber2 = customerDto.PhoneNumber2,
                    Email = customerDto.Email,
                    Adresse = customerDto.Adresse,
                    City = customerDto.City,
                    Land = customerDto.Land,
                    IsActivate = customerDto.IsActivate,
                    CreatedBy = customerDto.CreatedBy,
                    DateCreated = customerDto.DateCreated
                };
                await _customerService.CreateCustomerAsync(customer);
                var responseDto = new CustomerDTO
                {
                    Name = customer.Name,
                    CreditLimit = customer.CreditLimit,
                    AccountBalance = customer.AccountBalance,
                    PhoneNumber1 = customer.PhoneNumber1,
                    PhoneNumber2 = customer.PhoneNumber2,
                    Email = customer.Email,
                    Adresse = customer.Adresse,
                    City = customer.City,
                    Land = customer.Land,
                    IsActivate = customer.IsActivate,
                    CreatedBy = customer.CreatedBy,
                    DateCreated = customer.DateCreated
                };
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating customer");
                return StatusCode(500, $"Internal Server Error : {ex}");
            }



        }

        // Update a customer
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (id != customerDto.CustomerId)
            {
                return BadRequest("Customer ID mismatch.");
            }

            var existingEmployee = await _customerService.GetCustomerByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound("Customer not found.");
            }

            var customer = new Customer
            {
                CustomerId = id,
                Name = customerDto.Name,
                CreditLimit = customerDto.CreditLimit,
                AccountBalance = customerDto.AccountBalance,
                PhoneNumber1 = customerDto.PhoneNumber1,
                PhoneNumber2 = customerDto.PhoneNumber2,
                Email = customerDto.Email,
                Adresse = customerDto.Adresse,
                City = customerDto.City,
                Land = customerDto.Land,
                IsActivate = customerDto.IsActivate,
                ModifiedBy = customerDto.ModifiedBy,
                DateModified = DateTime.UtcNow
            };

            await _customerService.UpdateCustomerAsync(customer);
            return NoContent();
        }

        [HttpPut("CreditLimit/{id}")]
        public async Task<IActionResult> UpdateCustomerCreditLimit(int id, decimal threshold)
        {
            if (threshold == 0)
            {
                return BadRequest("Threshold must be a non-zero value.");
            }

            try
            {
                var updatedProduct = await _customerService.UpdateCustomerThresHoldAsync(id, threshold);
                if (updatedProduct == null)
                {
                    return NotFound("Customer not found.");
                }

                return Ok(updatedProduct); // Return the updated product for client confirmation.
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // Handle specific service-layer exceptions.
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is configured) and return a generic error message.
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }



        // Delete a customer
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }


        //// Get Customer by Name
        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerByName(string name)
        {
            try
            {
                var customer = await _customerService.GetCustomerByNameAsync(name);
                return Ok(customer);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving customer by name");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
