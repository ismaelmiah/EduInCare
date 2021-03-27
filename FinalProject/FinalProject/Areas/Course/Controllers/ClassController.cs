using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Course.Controllers
{
    [Area("Course")]
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
