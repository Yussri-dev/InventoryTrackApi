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
    ////[Authorize]
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
        ////[Authorize]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetPagedCustomers(int pageNumber = 1, int pageSize = 10)
        {
            var customers = await _customerService.GetPagedCustomersAsync(pageNumber, pageSize);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        ////[Authorize]
        public async Task<ActionResult<CustomerDTO>> GetCustomer([FromRoute]int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        ////[Authorize]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerDTO customerDto)
        {
            _logger.LogInformation($"Create Customer request for Customer: {customerDto}");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Customer");
            }
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                await _customerService.CreateCustomerAsync(customer);

                var responseDto = _mapper.Map<CustomerDTO>(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating Customer : {ex.Message}");
                return Problem(
                    title: "An error occured while creating the customer",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                    );
                throw;
            }
        }

       
        [HttpPut("{id}")]
        ////[Authorize]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, CustomerDTO customerDto)
        {
            _logger.LogInformation($"Update Customer request received for Id : {id}");
            if (id != customerDto.CustomerId)
            {
                _logger.LogWarning($"Customer ID mismatch : Route Id {id} does not match DTO ID {customerDto.CustomerId}");
                return BadRequest("Customer ID mismatch");
            }
            try
            {
                var existingCustomer = await _customerService.GetCustomerByIdAsync(id);
                if (existingCustomer == null)
                {
                    _logger.LogWarning($"Customer with ID : {id} not found");
                    return NotFound("Customer Not Found");
                }

                _logger.LogInformation($"Updating customer with Id {id}");
                var customer = _mapper.Map<Customer>(customerDto);
                await _customerService.UpdateCustomerAsync(customer);

                _logger.LogInformation($"customer with ID {id} successfully updated");
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Customer with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPatch("{id}")]
        ////[Authorize]
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

            return Ok(customerDto);
        }

        [HttpPut("CreditLimit/{id}")]
        ////[Authorize]
        public async Task<IActionResult> UpdateCustomerCreditLimit([FromRoute]int id, decimal amount, decimal amountPaid, string validate)
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
        ////[Authorize]
        public async Task<IActionResult> UpdateAccountBalance([FromRoute] int id, decimal amount)
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
        ////[Authorize]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }

        [HttpGet("Name/{name}")]
        ////[Authorize]
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
        ////[Authorize]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetSpecificCustomers()
        {
            var customers = await _customerService.GetSpecificCustomersAsync();
            return Ok(customers);
        }


    }
}
