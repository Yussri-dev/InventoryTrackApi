using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(CategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        // Get paged categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _categoryService.GetPagedCategoriesAsync(pageNumber, pageSize);
            return Ok(categories);
        }

        // Get category by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // Create a new category
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var category = new Category
                {
                    Name = categoryDto.Name,
                };

                await _categoryService.CreateCategoryAsync(category);

                var responseDto = new CategoryDTO
                {
                    Name = category.Name,
                };

                return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update a category
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTO categoryDto)
        {
            if (id != categoryDto.CategoryId)
            {
                return BadRequest("Category ID mismatch.");
            }

            var existingEmployee = await _categoryService.GetCategoryByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound("Category not found.");
            }

            var category = new Category
            {
                CategoryId = id,
                Name = categoryDto.Name
            };

            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }

        // Delete a category
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

        //// Get product by Name
        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<LineDTO>> GetCategoryByName(string name)
        {
            try
            {
                var unit = await _categoryService.GetCategoryByNameAsync(name);
                return Ok(unit);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving unit by name");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
