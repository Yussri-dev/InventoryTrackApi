using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class InventoryService
    {
        //private readonly IGenericRepository<Inventory> _inventoryRepository;

        //public InventoryService(IGenericRepository<Inventory> inventoryRepository)
        //{
        //    _inventoryRepository = inventoryRepository;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public InventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get All Inventories with Pagination
        public async Task<IEnumerable<Inventory>> GetPagedInventoryAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Inventorys.GetAllAsync(pageNumber, pageSize);
        }

        //Get Inventory By Id
        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _unitOfWork.Inventorys.GetByIdAsync(id);
        }

        // Create a new inventory
        public async Task CreateInventoryAsync(Inventory inventory)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.Inventorys.CreateAsync(inventory);
                await _unitOfWork.RollbackAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        //Update an existing Inventory
        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            var existingInventory = await _unitOfWork.Inventorys.GetByIdAsync(inventory.InventoryId);
            if (existingInventory == null)
            {
                throw new InvalidOperationException("Inventory Not Found");
            }

            existingInventory.Quantity = inventory.Quantity;
            existingInventory.ModifiedBy = inventory.ModifiedBy;
            existingInventory.DateModified = inventory.DateModified;

            await _unitOfWork.Inventorys.UpdateAsync(existingInventory);
        }

        //Delete an Inventory by Id
        public async Task DeleteInventoryAsync(int id)
        {
            await _unitOfWork.Inventorys.DeleteAsync(id);
        }
    }
}
