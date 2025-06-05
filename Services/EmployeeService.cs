using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //Get All Employee with Pagination
        public async Task<IEnumerable<Employee>> GetPagedEmployeeAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Employees.GetAllAsync(pageNumber, pageSize);
        }

        //Get Employee By Id
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.Employees.GetByIdAsync(id);
        }

        //Get Employee By Name
        public async Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string name)
        {
            return await _unitOfWork.Employees.GetByNameAsync(e => e.FirstName.Contains(name));
        }

        //Create a new Employee 
        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                bool exists = await _unitOfWork.Employees.ExistsAsync(p => p.NameComplete == employee.NameComplete);

                if (exists)
                {
                    throw new InvalidOperationException("Employee with the same Rate already exists.");
                }
                await _unitOfWork.Employees.CreateAsync(employee);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        //Update an Existing Employee
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _unitOfWork.Employees.GetByIdAsync(employee.EmployeeId);

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

            await _unitOfWork.Employees.UpdateAsync(existingEmployee);
        }


        //Delete an existing Row By Id
        public async Task DeleteEmployeeAsync(int Id)
        {
            await _unitOfWork.Employees.DeleteAsync(Id);
        }
    }
}
