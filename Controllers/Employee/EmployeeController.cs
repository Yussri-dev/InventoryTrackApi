using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(EmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Get paged employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetPagedEmployees(int pageNumber = 1, int pageSize = 10)
        {
            var pagedEmployees = await _employeeService.GetPagedEmployeeAsync(pageNumber, pageSize);
            return Ok(pagedEmployees);
        }

        // Get employee by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }
            return Ok(employee);
        }
        /*
        // Create a new employee
        [HttpPost]

        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeDTO employeeDto)
        {
            try
            {
                var employee = new Employee
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    Role = employeeDto.Role,
                    Phone = employeeDto.Phone,
                    Email = employeeDto.Email,
                    PasswordHash = employeeDto.PasswordHash
                };

                await _employeeService.CreateEmployeeAsync(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employeeDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        */

        // Create a new employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeDTO employeeDto)
        {
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
        }


        // Update an existing employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDTO employeeDto)
        {
            if (id != employeeDto.EmployeeId)
            {
                return BadRequest("Employee ID mismatch.");
            }

            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound("Employee not found.");
            }

            var employee = new Models.Employee
            {
                EmployeeId = id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Role = employeeDto.Role,
                Phone = employeeDto.Phone,
                Email = employeeDto.Email,
                PasswordHash = employeeDto.PasswordHash
            };

            await _employeeService.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        // Delete an employee
        [HttpDelete("{id}")]
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
