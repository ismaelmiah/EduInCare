using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Administrative.Controllers
{
    [Area("Administrative")]
    public class AdministrativeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
