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
            var model = new StudentFormModel();

            if (id == null)
                return View(model);

            model = model.GetStudentModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(StudentFormModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.SaveStudent();
                }
                else
                {
                    //Update
                    model.UpdateStudent();
                }
            }
            return RedirectToRoute(new { Area="", controller = "Home", action = "Index"});
        }
        public IActionResult Delete(Guid id)
        {
            var model = new StudentFormModel();
            model.DeleteStudent(id);
            return RedirectToRoute(new{Area = "Admin", controller = "Student", action = "Index"});
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
