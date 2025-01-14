using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class UnitService
    {
        private readonly IGenericRepository<Unit> _unitRepository;

        // Constructor to inject the repository
        public UnitService(IGenericRepository<Unit> unitRepository)
        {
            _unitRepository = unitRepository;
        }
        // Get all units with pagination
        public async Task<IEnumerable<Unit>> GetPagedUnitsAsync(int pageNumber, int pageSize)
        {
            return await _unitRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get a unit by ID
        public async Task<Unit> GetUnitByIdAsync(int id)
        {
            return await _unitRepository.GetByIdAsync(id);
        }

        //Get a product by Name
        public async Task<IEnumerable<Unit>> GetUnitByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _unitRepository.GetByNameAsync(p => p.Name.Contains(name));
        }

        // Create a new unit
        public async Task CreateUnitAsync(Unit unit)
        {
            await _unitRepository.CreateAsync(unit);
        }

        // Update an existing unit
        public async Task UpdateUnitAsync(Unit unit)
        {
            var existingUnit = await _unitRepository.GetByIdAsync(unit.UnitId);

            if (existingUnit == null)
            {
                throw new InvalidOperationException("Unit Not Found");
            }

            existingUnit.Name = existingUnit.Name;

            await _unitRepository.UpdateAsync(existingUnit);
        }

        // Delete a unit by ID
        public async Task DeleteUnitAsync(int id)
        {
            await _unitRepository.DeleteAsync(id);
        }
    }
}
