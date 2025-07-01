using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApiProject.WebUI.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace MyApiProject.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ProductList()
        {
            var client = _httpClientFactory.CreateClient(); // Use the default client configuration
            var response = await client.GetAsync("https://localhost:7109/api/Product");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient(); // Use the default client configuration
            var response = await client.GetAsync("https://localhost:7109/api/Category");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.categoryName,
                                                Value = x.categoryId.ToString()
                                            }).ToList();
            ViewBag.v = values2; // Pass the categories to the view
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient(); // Use the default client configuration
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7109/api/Product", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();

        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient(); // Use the default client configuration
            var response = await client.DeleteAsync("https://localhost:7109/api/Product?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient(); // Use the default client configuration
            var response = await client.GetAsync("https://localhost:7109/api/Category");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.categoryName,
                                                Value = x.categoryId.ToString()
                                            }).ToList();
            ViewBag.v = values2; // Pass the products to the view

            var client2 = _httpClientFactory.CreateClient(); // Use the default client configuration
            var response2 = await client2.GetAsync("https://localhost:7109/api/Product/GetProduct?id=" + id);
            if (response2.IsSuccessStatusCode)
            {
                var jsonData2 = await response2.Content.ReadAsStringAsync();
                var updatedValues = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData2);
                return View(updatedValues);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient(); // Use the default client configuration
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7109/api/Product/", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();

        }

    }
}