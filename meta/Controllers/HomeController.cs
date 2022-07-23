using Microsoft.AspNetCore.Mvc;

namespace meta.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
