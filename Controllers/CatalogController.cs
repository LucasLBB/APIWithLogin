using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
