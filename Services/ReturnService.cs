using InventoryTrackApi.Models;
using InventoryTrackApi.Queries;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class ReturnService
    {
        private readonly IGenericRepository<Return> _returnRepository;
        public ReturnService(IGenericRepository<Return> returnRepository)
        {
            _returnRepository = returnRepository;
        }

        // Get all returns with pagination
        public async Task<IEnumerable<Return>> GetPagedReturnsAsync(int pageNumber, int pageSize)
        {
            return await _returnRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get a return by ID
        public async Task<Return> GetReturnByIdAsync(int id)
        {
            return await _returnRepository.GetByIdAsync(id);
        }

        // Create a new return
        public async Task CreateReturnAsync(Return returnModel)
        {
            await _returnRepository.CreateAsync(returnModel);
        }

        // Update an existing return
        public async Task UpdateReturnAsync(Return returnModel)
        {
            var existingReturn = await _returnRepository.GetByIdAsync(returnModel.ReturnId);

            if (existingReturn == null)
            {
                throw new InvalidOperationException("Return Not Found");
            }
            
            existingReturn.returnDate = returnModel.returnDate;
            existingReturn.CustomerId = returnModel.CustomerId;
            existingReturn.EmployeeId = returnModel.EmployeeId;
            existingReturn.Reason = returnModel.Reason;
            existingReturn.Status = returnModel.Status;
            existingReturn.RefundAmount = returnModel.RefundAmount;
            existingReturn.ReturnMethod = returnModel.ReturnMethod;

            await _returnRepository.UpdateAsync(existingReturn);
        }

        

        // Delete a return by ID
        public async Task DeleteReturnAsync(int id)
        {
            await _returnRepository.DeleteAsync(id);
        }

        public async Task<int> CountReturnsAsync()
        {
            return await _returnRepository.CountAsync();
        }

    }
}
