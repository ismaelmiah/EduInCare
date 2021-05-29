using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new WebsiteModel();
            return View(model);
        }

        public IActionResult Classes()
        {
            return View();
        }

        public IActionResult Teachers()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
