using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(EmployeeService employeeService, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get paged employees
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetPagedEmployees(int pageNumber = 1, int pageSize = 10)
        {
            var pagedEmployees = await _employeeService.GetPagedEmployeeAsync(pageNumber, pageSize);
            return Ok(pagedEmployees);
        }

        // Get employee by ID
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee([FromRoute]int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }
            return Ok(employee);
        }

        //// Get product by Name
        [HttpGet("Name/{name}")]
        //[Authorize]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeByName([FromRoute] string name)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByNameAsync(name);
                return Ok(employee);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving Employee name");
                return StatusCode(500, "Internal server error");
            }
        }


        // Create a new employee
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeDTO employeeDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for Creating Employee.");
                return ValidationProblem(ModelState);
            }
            try
            {
                var employee = _mapper.Map<Models.Employee>(employeeDto);
                await _employeeService.CreateEmployeeAsync(employee);

                var respondDto = _mapper.Map<EmployeeDTO>(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = employee }, respondDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Creating Purchase: {ex.Message}");
                return Problem(
                    title: "An error occurred while creating the employee.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
            /*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var employee = new Models.Employee
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    Role = employeeDto.Role,
                    Phone = employeeDto.Phone,
                    Email = employeeDto.Email,
                    //PasswordHash = HashPassword(employeeDto.PasswordHash) // Compute securely
                    PasswordHash = employeeDto.PasswordHash
                };

                await _employeeService.CreateEmployeeAsync(employee);

                var responseDto = new EmployeeDTO
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Role = employee.Role,
                    Email = employee.Email,
                    Phone = employee.Phone
                };

                return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            */
        }


        // Update an existing employee
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateEmployee([FromRoute]int id, EmployeeDTO employeeDto)
        {
            if (id != employeeDto.EmployeeId)
            {
                return BadRequest("Purchase ID mismatch.");
            }

            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound("Purchase not found.");
            }

            var purchase = _mapper.Map<Models.Employee>(employeeDto);
            await _employeeService.UpdateEmployeeAsync(purchase);
            return NoContent();
        }

        // Delete an employee
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound("Employee not found.");
            }

            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
