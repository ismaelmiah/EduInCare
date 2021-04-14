using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExamController : Controller
    {
        public IActionResult Exams()
        {
            return View();
        }

        public IActionResult UpsertExam()
        {
            return View();
        }

        public IActionResult UpsertRule()
        {
            return View();
        }

        public IActionResult Rules()
        {
            return View();
        }
    }
}
