using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new WebsiteModel
            {
                Header = new HeaderModel(),
                Footer = new FooterModel(),
                Advertise = new AdvertiseModel(),
                Notice = new NoticeModel(),
                Post = new PostModel()
            };
            return View(model);
        }
    }
}
