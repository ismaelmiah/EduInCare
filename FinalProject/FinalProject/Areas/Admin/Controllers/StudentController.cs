using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert()
        {
            return View();
        }
        public IActionResult Delete(Guid id)
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult StudentReport(Guid id)
        {
            return View();
        }
    }
}
