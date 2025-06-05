using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class UnitService
    {
        //private readonly IGenericRepository<Unit> _unitRepository;

        //// Constructor to inject the repository
        //public UnitService(IGenericRepository<Unit> unitRepository)
        //{
        //    _unitRepository = unitRepository;
        //}

        private readonly IUnitOfWork _unitOfWork;

        public UnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = _unitOfWork;
        }
        // Get all units with pagination
        public async Task<IEnumerable<Unit>> GetPagedUnitsAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Units.GetAllAsync(pageNumber, pageSize);
        }

        // Get a unit by ID
        public async Task<Unit> GetUnitByIdAsync(int id)
        {
            return await _unitOfWork.Units.GetByIdAsync(id);
        }

        //Get a product by Name
        public async Task<IEnumerable<Unit>> GetUnitByNameAsync(string name)
        {
            return await _unitOfWork.Units.GetByNameAsync(p => p.Name.Contains(name));
        }

        // Create a new unit
        public async Task CreateUnitAsync(Unit unit)
        {
            bool exists = await _unitOfWork.Units.ExistsAsync(p => p.Name == unit.Name);

            if (exists)
            {
                throw new InvalidOperationException("Unit with the same name already exists.");
            }

            await _unitOfWork.Units.CreateAsync(unit);
        }

        // Update an existing unit
        public async Task UpdateUnitAsync(Unit unit)
        {
            var existingUnit = await _unitOfWork.Units.GetByIdAsync(unit.UnitId);

            if (existingUnit == null)
            {
                throw new InvalidOperationException("Category not found.");
            }

            existingUnit.Name = unit.Name;
            //
            await _unitOfWork.Units.UpdateAsync(existingUnit);
        }

        // Delete a unit by ID
        public async Task DeleteUnitAsync(int id)
        {
            await _unitOfWork.Units.DeleteAsync(id);
        }
    }
}
