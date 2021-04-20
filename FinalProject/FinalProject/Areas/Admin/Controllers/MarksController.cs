using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    public class MarksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
