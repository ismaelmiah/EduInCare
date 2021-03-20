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
        public IActionResult Upsert(Guid? id)
        {
            var model = new StudentFormViewModel();

            if (id == null)
                return View(model);

            model = model._modelBuilder.BuildStudentModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(StudentFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model._modelBuilder.SaveStudent(model);
                }
                else
                {
                    //Update
                    model._modelBuilder.UpdateStudent(model.Id, model);
                }
            }
            return RedirectToRoute(new { Area="", controller = "Home", action = "Index"});
        }

        public IActionResult Delete(Guid id)
        {
            var model = new StudentFormViewModel();
            model._modelBuilder.DeleteStudent(id);
            return RedirectToRoute(new{Area = "Admin", controller = "Student", action = "Index"});
        }
        public IActionResult StudentReport(Guid id)
        {
            return View();
        }

        public IActionResult Profile(Guid id)
        {
            var model = new StudentFormViewModel();

            model = model._modelBuilder.BuildStudentModel(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
    }
}
