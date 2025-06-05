using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // Get all categorys with pagination
        public async Task<IEnumerable<Category>> GetPagedCategoriesAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Categories.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<int> CountCategoriesAsync()
        {
            return await _unitOfWork.Categories.CountAsync();
        }
        //Get a product by Name
        public async Task<IEnumerable<Category>> GetCategoryByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _unitOfWork.Categories.GetByNameAsync(p => p.Name.Contains(name));
        }

        // Get a category by ID
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        // Create a new category
        public async Task CreateCategoryAsync(Category category)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                bool exists = await _unitOfWork.Categories.ExistsAsync(p => p.Name == category.Name);

                if (exists)
                {
                    throw new InvalidOperationException("Category with the same Rate already exists.");
                }

                await _unitOfWork.Categories.CreateAsync(category);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

        }

        // Update an existing category
        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _unitOfWork.Categories.GetByIdAsync(category.CategoryId);

            if (existingCategory == null)
            {
                throw new InvalidOperationException("Category not found.");
            }

            existingCategory.Name = category.Name;
            //
            await _unitOfWork.Categories.UpdateAsync(existingCategory);
        }

        // Delete a category by ID
        public async Task DeleteCategoryAsync(int id)
        {
            await _unitOfWork.Categories.DeleteAsync(id);
        }
    }
}
