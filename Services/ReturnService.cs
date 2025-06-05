using InventoryTrackApi.Models;
using InventoryTrackApi.Queries;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class ReturnService
    {
        //private readonly IGenericRepository<Return> _returnRepository;
        //public ReturnService(IGenericRepository<Return> returnRepository)
        //{
        //    _returnRepository = returnRepository;
        //}
        private readonly IUnitOfWork _unitOfWork;
        public ReturnService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // Get all returns with pagination
        public async Task<IEnumerable<Return>> GetPagedReturnsAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Returns.GetAllAsync(pageNumber, pageSize);
        }

        // Get a return by ID
        public async Task<Return> GetReturnByIdAsync(int id)
        {
            return await _unitOfWork.Returns.GetByIdAsync(id);
        }

        // Create a new return
        public async Task CreateReturnAsync(Return returnModel)
        {
            await _unitOfWork.Returns.CreateAsync(returnModel);
        }

        // Update an existing return
        public async Task UpdateReturnAsync(Return returnModel)
        {
            var existingReturn = await _unitOfWork.Returns.GetByIdAsync(returnModel.ReturnId);

            if (existingReturn == null)
            {
                throw new InvalidOperationException("Return Not Found");
            }
            
            existingReturn.ReturnDate = returnModel.ReturnDate;
            existingReturn.CustomerId = returnModel.CustomerId;
            existingReturn.EmployeeId = returnModel.EmployeeId;
            existingReturn.Reason = returnModel.Reason;
            existingReturn.Status = returnModel.Status;
            existingReturn.RefundAmount = returnModel.RefundAmount;
            existingReturn.ReturnMethod = returnModel.ReturnMethod;

            await _unitOfWork.Returns.UpdateAsync(existingReturn);
        }

        

        // Delete a return by ID
        public async Task DeleteReturnAsync(int id)
        {
            await _unitOfWork.Returns.DeleteAsync(id);
        }

        public async Task<int> CountReturnsAsync()
        {
            return await _unitOfWork.Returns.CountAsync();
        } 

    }
}
