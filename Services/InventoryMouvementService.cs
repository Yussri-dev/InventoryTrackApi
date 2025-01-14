using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class InventoryMouvementService
    {
        private readonly IGenericRepository<InventoryMouvement> _inventoryMouvementRepository;

        public InventoryMouvementService(IGenericRepository<InventoryMouvement> inventoryMouvementRepository)
        {
            _inventoryMouvementRepository = inventoryMouvementRepository;
        }

        // Get All InventoryMouvement With Pagination
        public async Task<IEnumerable<InventoryMouvement>> GetPagedInventoryMouvementAsync(int pageNumber, int pageSize)
        {
            return await _inventoryMouvementRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get Inventory By Id
        public async Task<InventoryMouvement> GetInventoryMouvementByIdAsync(int id)
        {
            return await _inventoryMouvementRepository.GetByIdAsync(id);
        }

        //Create a new InventoryMouvement
        public async Task CreateInventoryMouvementAsync(InventoryMouvement inventoryMouvement)
        {
            await _inventoryMouvementRepository.CreateAsync(inventoryMouvement);
        }

        //Update an existing Inventory Mouvement
        public async Task UpdateInventoryMouvementAsync(InventoryMouvement inventoryMouvement)
        {
            var existingInventoryMouvement = await _inventoryMouvementRepository.GetByIdAsync(inventoryMouvement.InventoryMouvementId);
            if (existingInventoryMouvement == null)
            {
                throw new InvalidOperationException("Inventory Mouvement Not Found");
            }
            existingInventoryMouvement.MouvementType = inventoryMouvement.MouvementType;
            existingInventoryMouvement.Quantity = inventoryMouvement.Quantity;
            existingInventoryMouvement.MouvementDate = inventoryMouvement.MouvementDate;

            await _inventoryMouvementRepository.UpdateAsync(existingInventoryMouvement);
        }

        //Delete an Inventory Mouvement
        public async Task DeleteInventoryMouvementAsync(int id)
        {
            await _inventoryMouvementRepository.DeleteAsync(id);
        }

    }
}
