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
    }
}
