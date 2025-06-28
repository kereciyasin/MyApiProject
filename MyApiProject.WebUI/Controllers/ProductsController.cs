using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
