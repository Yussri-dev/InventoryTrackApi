using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class InventoryService
    {
        private readonly IGenericRepository<Inventory> _inventoryRepository;

        public InventoryService(IGenericRepository<Inventory> inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        // Get All Inventories with Pagination
        public async Task<IEnumerable<Inventory>> GetPagedInventoryAsync(int pageNumber, int pageSize)
        {
            return await _inventoryRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get Inventory By Id
        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _inventoryRepository.GetByIdAsync(id);
        }

        // Create a new inventory
        public async Task CreateInventoryAsync(Inventory inventory)
        {
            await _inventoryRepository.CreateAsync(inventory);
        }

        //Update an existing Inventory
        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            var existingInventory = await _inventoryRepository.GetByIdAsync(inventory.InventoryId);
            if (existingInventory == null)
            {
                throw new InvalidOperationException("Inventory Not Found");
            }
            
            existingInventory.Quantity = inventory.Quantity;
            existingInventory.ModifiedBy = inventory.ModifiedBy;
            existingInventory.DateModified = inventory.DateModified;

            await _inventoryRepository.UpdateAsync(existingInventory);
        }

        //Delete an Inventory by Id
        public async Task DeleteInventoryAsync(int id)
        {
            await _inventoryRepository.DeleteAsync(id);
        }
    }
}
