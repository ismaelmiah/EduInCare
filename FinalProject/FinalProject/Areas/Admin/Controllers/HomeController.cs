using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Header()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Footer()
        {
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }
        
        public IActionResult Notice()
        {
            return View();
        }

        public IActionResult Advertise()
        {
            return View();
        }
    }
}
