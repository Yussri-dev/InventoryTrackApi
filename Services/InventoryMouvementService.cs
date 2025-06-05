using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class InventoryMouvementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InventoryMouvementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get All InventoryMouvement With Pagination
        public async Task<IEnumerable<InventoryMouvement>> GetPagedInventoryMouvementAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.InventoryMouvements.GetAllAsync(pageNumber, pageSize);
        }

        //Get Inventory By Id
        public async Task<InventoryMouvement> GetInventoryMouvementByIdAsync(int id)
        {
            return await _unitOfWork.InventoryMouvements.GetByIdAsync(id);
        }

        //Create a new InventoryMouvement
        public async Task CreateInventoryMouvementAsync(InventoryMouvement inventoryMouvement)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.InventoryMouvements.CreateAsync(inventoryMouvement);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        //Update an existing Inventory Mouvement
        public async Task UpdateInventoryMouvementAsync(InventoryMouvement inventoryMouvement)
        {
            var existingInventoryMouvement = await _unitOfWork.InventoryMouvements.GetByIdAsync(inventoryMouvement.InventoryMouvementId);
            if (existingInventoryMouvement == null)
            {
                throw new InvalidOperationException("Inventory Mouvement Not Found");
            }
            existingInventoryMouvement.MouvementType = inventoryMouvement.MouvementType;
            existingInventoryMouvement.Quantity = inventoryMouvement.Quantity;
            existingInventoryMouvement.MouvementDate = inventoryMouvement.MouvementDate;

            await _unitOfWork.InventoryMouvements.UpdateAsync(existingInventoryMouvement);
        }

        //Delete an Inventory Mouvement
        public async Task DeleteInventoryMouvementAsync(int id)
        {
            await _unitOfWork.InventoryMouvements.DeleteAsync(id);
        }

    }
}
