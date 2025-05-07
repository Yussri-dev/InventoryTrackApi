using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class CategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        // Constructor to inject the repository
        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // Get all categorys with pagination
        public async Task<IEnumerable<Category>> GetPagedCategoriesAsync(int pageNumber, int pageSize)
        {
            return await _categoryRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get a product by Name
        public async Task<IEnumerable<Category>> GetCategoryByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _categoryRepository.GetByNameAsync(p => p.Name.Contains(name));
        }

        // Get a category by ID
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        // Create a new category
        public async Task CreateCategoryAsync(Category category)
        {
            bool exists = await _categoryRepository.ExistsAsync(p => p.Name == category.Name);

            if (exists)
            {
                throw new InvalidOperationException("Category with the same Rate already exists.");
            }

            await _categoryRepository.CreateAsync(category);
        }

        // Update an existing category
        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(category.CategoryId);

            if (existingCategory == null)
            {
                throw new InvalidOperationException("Category not found.");
            }

            existingCategory.Name = category.Name;
            //
            await _categoryRepository.UpdateAsync(existingCategory);
        }

        // Delete a category by ID
        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}
