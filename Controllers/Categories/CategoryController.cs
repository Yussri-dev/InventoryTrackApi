using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;
        public CategoryController(CategoryService categoryService, 
            ILogger<CategoryController> logger,
            IMapper mapper)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get paged categories
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _categoryService.GetPagedCategoriesAsync(pageNumber, pageSize);
            return Ok(categories);
        }

        // Get category by ID
        [HttpGet("{id}")]
        [Authorize]
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
        [Authorize]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Category");
                return ValidationProblem(ModelState);
            }

            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                await _categoryService.CreateCategoryAsync(category);

                var responseDto = _mapper.Map<CategoryDTO>(category);
                //var category = new Category
                //{
                //    Name = categoryDto.Name,
                //};

                //await _categoryService.CreateCategoryAsync(category);

                //var responseDto = new CategoryDTO
                //{
                //    Name = category.Name,
                //};

                return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Creating Category: {ex.Message}");
                return Problem(
                    title: "An error occurred while creating the purchase.",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        // Update a category
        [HttpPut("{id}")]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

        //// Get product by Name
        [HttpGet("ByName/{name}")]
        [Authorize]
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
