using System;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Web.Areas.Admin.Models;
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
            var data = model.ModelBuilder.GetClasses(tableModel);
            return Json(data);
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new CourseModel();

            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildCourseModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CourseModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveCourse(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateCourse(model.Id, model);
                }
            }
            return RedirectToRoute(new { Area = "Admin", controller = "Course", action = "Index" });
        }


        public IActionResult Delete(Guid id)
        {
            var model = new CourseModel();
            model.ModelBuilder.DeleteCourse(id);
            return RedirectToRoute(new { Area = "Admin", controller = "Course", action = "Index" });
        }
    }
}
