using Microsoft.AspNetCore.Mvc;

namespace meta.Areas.Inventory.Controllers
{
    public class StorsController : Controller
    {
        [Area("Inventory")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
