using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class ShelfService
    {
        //private readonly IGenericRepository<Shelf> _shelfRepository;

        ////Ctor to inject The repository
        //public ShelfService(IGenericRepository<Shelf> shelfRepository)
        //{
        //    _shelfRepository = shelfRepository;
        //}
        private readonly IUnitOfWork _unitOfWork;
        public ShelfService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //Get All Shelf with Pagination
        public async Task<IEnumerable<Shelf>> GetPagedShelfs(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Shelfs.GetAllAsync(pageNumber, pageSize);
        }

        //Get a Shelf by Id
        public async Task<Shelf>GetShelfByIdAsync(int id)
        {
            return await _unitOfWork.Shelfs.GetByIdAsync(id);
        }

        //Get a product by Name
        public async Task<IEnumerable<Shelf>> GetShelfByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _unitOfWork.Shelfs.GetByNameAsync(p => p.Name.Contains(name));
        }

        //create a new Shelf
        public async Task CreateShelfAsync(Shelf shelf)
        {

            bool exists = await _unitOfWork.Shelfs.ExistsAsync(p => p.Name == shelf.Name);

            if (exists)
            {
                throw new InvalidOperationException("Shelf with the same Rate already exists.");
            }
            await _unitOfWork.Shelfs.CreateAsync(shelf);
        }

        //Update an Existing Shelf
        public async Task UpdateShelfAsync(Shelf shelf)
        {
            // Check if the shelf exists first
            var existingShelf = await _unitOfWork.Shelfs.GetByIdAsync(shelf.ShelfId);
            //var existingShelf = GetShelfByIdAsync(shelf.ShelfId);
            if (existingShelf == null)
            {
                throw new InvalidOperationException("Shelf not found.");
            }

            // Update the properties of the existing shelf
            existingShelf.Name = shelf.Name;

            // Call the repository to update the existing shelf in the database
            await _unitOfWork.Shelfs.UpdateAsync(existingShelf);
        }

        //Delete a shelf by Id
        public async Task DeleteShelfAsync(int id)
        {
            await _unitOfWork.Shelfs.DeleteAsync(id);
        }
    }
}
