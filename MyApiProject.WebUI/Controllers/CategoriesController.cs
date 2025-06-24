using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult CategoryList()
        {
            return View();
        }
    }
}
