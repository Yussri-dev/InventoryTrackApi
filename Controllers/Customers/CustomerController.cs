using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryTrackApi.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;
        public CustomerController(CustomerService customerService, ILogger<CustomerController> logger, IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        //[AllowAnonymous]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var customers = await _customerService.GetPagedCustomersAsync(pageNumber, pageSize);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for Creating Customer.");
                return ValidationProblem(ModelState);
            }
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                await _customerService.CreateCustomerAsync(customer);

                var respondDto = _mapper.Map<CustomerDTO>(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, respondDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Creating Customer: {ex.Message}");
                return Problem(
                    title: "An error occurred while creating the Customer.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }


        /*
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
        */

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, CustomerDTO customerDto)
        {
            if (id != customerDto.CustomerId)
            {
                return BadRequest("Customer ID mismatch.");
            }

            var existingCustomer = await _customerService.GetCustomerByIdAsync(id);
            if (existingCustomer == null)
            {
                return NotFound("Customer not found.");
            }

            var customer = _mapper.Map<Customer>(customerDto);
            await _customerService.UpdateCustomerAsync(customer);

            return Ok(customer);
        }

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> PatchCustomer([FromRoute] int id, [FromBody] JsonPatchDocument<CustomerDTO> patchCustomer)
        {
            if (patchCustomer == null)
            {
                return BadRequest("Invalid patch document.");
            }

            var existingCustomer = await _customerService.GetCustomerByIdAsync(id);
            if (existingCustomer == null)
            {
                return NotFound("Customer not found.");
            }

            var customerDto = _mapper.Map<CustomerDTO>(existingCustomer);

            patchCustomer.ApplyTo(customerDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(customerDto, existingCustomer);

            await _customerService.UpdateCustomerAsync(existingCustomer);

            //return Ok(_mapper.Map<CustomerDTO>(existingCustomer));
            return NoContent();

        }

        [HttpPut("CreditLimit/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCustomerCreditLimit(int id, decimal amount, decimal amountPaid, string validate)
        {
            //if (amount == 0)
            //{
            //    return BadRequest("Threshold must be a non-zero value.");
            //}
            try
            {
                var updatedProduct = await _customerService.UpdateCustomerThresHoldAsync(id, amount, amountPaid, validate);
                if (updatedProduct == null)
                {
                    return NotFound("Customer not found.");
                }
                return Ok(updatedProduct);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the customer {ex}.");
            }
        }

        [HttpPut("AccountBalance")]
        [Authorize]
        public async Task<IActionResult> UpdateAccountBalance(int id, decimal amount)
        {
            if (amount == 0)
            {
                return BadRequest("Amount must be a non-zero value.");
            }

            try
            {
                var updatedProduct = await _customerService.UpdateAccountBalanceAsync(id, amount);
                if (updatedProduct == null)
                {
                    return NotFound("Customer not found.");
                }

                return Ok(updatedProduct);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the product. {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }

        [HttpGet("ByName/{name}")]
        [Authorize]
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

        [HttpGet("Credit")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetSpecificCustomers()
        {
            var customers = await _customerService.GetSpecificCustomersAsync();
            return Ok(customers);
        }


    }
}
