using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AcademicYearController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
