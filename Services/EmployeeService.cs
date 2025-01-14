using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class EmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        //Get All Employee with Pagination
        public async Task<IEnumerable<Employee>> GetPagedEmployeeAsync(int pageNumber, int pageSize)
        {
            return await _employeeRepository.GetAllAsync(pageNumber, pageSize); 
        }

        //Get Employee By Id
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        //Create a new Employee 
        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.CreateAsync(employee);
        }
        
        //Update an Existing Employee
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(employee.EmployeeId);
           
            if (existingEmployee == null)
            {
                throw new InvalidOperationException("Employee not found.");
            }

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Role = employee.Role;
            existingEmployee.Phone = employee.Phone;
            existingEmployee.Email = employee.Email;
            existingEmployee.PasswordHash = employee.PasswordHash;

            await _employeeRepository.UpdateAsync(existingEmployee);
        }


        //Delete an existing Row By Id
        public async Task DeleteEmployeeAsync(int Id)
        {
            await _employeeRepository.DeleteAsync(Id);
        }
    }
}
