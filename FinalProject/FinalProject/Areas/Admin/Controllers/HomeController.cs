using FinalProject.Areas.Admin.Models;
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
        [HttpPost]
        public IActionResult Header(HeaderModel model)
        {
            model.SaveHeader();
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
        [HttpPost]
        public IActionResult Footer(FooterModel model)
        {
            model.SaveFooter();
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Post(PostViewModel model)
        {
            model.SavePost();
            return View();
        }
        
        public IActionResult Notice()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Notice(NoticeViewModel model)
        {
            model.SaveNotice();
            return View();
        }

        public IActionResult Advertise()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Advertise(AdvertiseModel model)
        {
            model.SaveAdvertise();
            return View();
        }
    }
}
