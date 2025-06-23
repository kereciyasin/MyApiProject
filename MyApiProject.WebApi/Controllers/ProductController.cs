using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.BusinessLayer.Abstract;
using MyApiProject.DtoLayer.ProductDtos;
using MyApiProject.EntityLayer.Concrete;

namespace MyApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _productService.TGetAll();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new Product();
            product.ProductName = createProductDto.ProductName;
            product.Price = createProductDto.Price;
            product.Stock = createProductDto.Stock;
            product.CategoryId = createProductDto.CategoryId; // Assuming CategoryId is part of UpdateProductDto
            _productService.TInsert(product);
            return Ok("Product created successfully.");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Product deleted successfully.");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            if (value == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product product = new Product();
            product.ProductId = updateProductDto.ProductId;
            product.ProductName = updateProductDto.ProductName;
            product.Price = updateProductDto.Price;
            product.Stock = updateProductDto.Stock;
            product.CategoryId = updateProductDto.CategoryId; // Assuming CategoryId is part of UpdateProductDto
            _productService.TUpdate(product);
            return Ok("Product updated successfully.");

        }
    }
}
