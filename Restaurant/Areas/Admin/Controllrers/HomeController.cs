using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Admin.Controllrers
{
    public class HomeController : Controller
    {
        [Area(areaName:"Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
