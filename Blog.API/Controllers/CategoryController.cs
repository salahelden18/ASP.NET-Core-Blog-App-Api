using Blog.Core.IServices;
using Blog.Core.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories =  await _categoryService.GetAllCategories();

            return Ok(categories);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory(CategoryDto categoryDto)
        {
            var category = await _categoryService.CreateCategory(categoryDto);

            return Ok(category);
        }

        [HttpPatch]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.UpdateCategory(id, categoryDto);

            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(CategoryDto categoryDto)
        {
            await _categoryService.DeleteCategory(categoryDto);

            return NoContent();
        }
    }
}
