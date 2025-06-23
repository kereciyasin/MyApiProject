using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.BusinessLayer.Abstract;
using MyApiProject.DtoLayer.CategoryDtos;
using MyApiProject.EntityLayer.Concrete;

namespace MyApiProject.WebApi.Controllers
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
        public IActionResult CategoryList()
        {
            var categories = _categoryService.TGetAll();
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            Category category = new Category();
            category.CategoryName = createCategoryDto.CategoryName;
            _categoryService.TInsert(category);
            return Ok("Category created successfully.");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Category deleted successfully.");
        }
        [HttpGet("GetCategory")]

        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value == null)
            {
                return NotFound("Category not found.");
            }
            return Ok(value);

        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var existingCategory = _categoryService.TGetById(category.CategoryId);
            if (existingCategory == null)
            {
                return NotFound("Category not found.");
            }
            _categoryService.TUpdate(category);
            return Ok("Category updated successfully.");
        }
        [HttpPut("UpdateCategoryDto")]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            Category category = new Category();
            category.CategoryId = updateCategoryDto.CategoryId;
            category.CategoryName = updateCategoryDto.CategoryName;
            _categoryService.TUpdate(category);
            return Ok("Category updated successfully using DTO.");
        }
    }
}