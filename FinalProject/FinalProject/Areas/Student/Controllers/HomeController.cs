using System;
using FinalProject.Web.Areas.Student.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert()
        {
            var model = new StudentFormModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Upsert(StudentFormModel model)
        {
            model.SaveStudent();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid id)
        {
            var model = new StudentFormModel();
            model.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult StudentReport(Guid id)
        {
            return View();
        }

        public IActionResult Profile(Guid id)
        {
            return View();
        }
    }
}
