using System;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Student.Models;
using FinalProject.Web.Models;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetClasses()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CourseModel();
            var data = model.GetClasses(tableModel);
            return Json(data);
        }

        public IActionResult Upsert()
        {
            var model = new CourseModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Upsert(CourseModel model)
        {
            model.SaveCourse();
            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            var model = new CourseModel();
            model.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
