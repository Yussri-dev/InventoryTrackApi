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
    //[Authorize]
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
        //[Authorize]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetPagedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _categoryService.GetPagedCategoriesAsync(pageNumber, pageSize);
            return Ok(categories);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCategoryCount()
        {
            try
            {
                int count = await _categoryService.CountCategoriesAsync();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Get category by ID
        [HttpGet("{id}")]
        //[Authorize]
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
        //[Authorize]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryDTO categoryDto)
        {
            _logger.LogInformation($"Create Category request for Category: {categoryDto}");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating Category");
            }
            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                await _categoryService.CreateCategoryAsync(category);

                var responseDto = _mapper.Map<CategoryDTO>(category);
                return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating Category : {ex.Message}");
                return Problem(
                    title: "An error occured while creating the category",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                    );
                throw;
            }
        }

        // Update a category
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTO categoryDto)
        {
            _logger.LogInformation($"Update Category request received for Id : {id}");
            if (id != categoryDto.CategoryId)
            {
                _logger.LogWarning($"Category ID mismatch : Route Id {id} does not match DTO ID {categoryDto.CategoryId}");
                return BadRequest("Category ID mismatch");
            }
            try
            {
                var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
                if (existingCategory == null)
                {
                    _logger.LogWarning($"Category with ID : {id} not fount");
                    return NotFound("Category Not Found");
                }

                _logger.LogInformation($"Updating category with Id {id}");
                var category = _mapper.Map<Category>(categoryDto);
                await _categoryService.UpdateCategoryAsync(category);

                _logger.LogInformation($"category with ID {id} successfully updated");
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating Category with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }

        // Delete a category
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

        //// Get product by Name
        [HttpGet("Name/{name}")]
        //[Authorize]
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
