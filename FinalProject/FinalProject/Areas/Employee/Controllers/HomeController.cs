using Microsoft.AspNetCore.Mvc;
using System;
using FinalProject.Web.Areas.Employee.Models;
using FinalProject.Web.Areas.Student.Models;

namespace FinalProject.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class HomeController : Controller
    {
        public IActionResult Upsert(Guid? id)
        {
            var model = new EmployeeFormViewModel();
            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildEmployeeModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(EmployeeFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.Id == new Guid())
            {
                //Create
                model.ModelBuilder.SaveEmployee(model);
            }
            else
            {
                //Update
                model.ModelBuilder.UpdateEmployee(model.Id, model);
            }
            return RedirectToRoute(new { Area = "Admin", controller = "Employee", action = "Index" });
        }

        public IActionResult Delete(Guid id)
        {
            var model = new EmployeeFormViewModel();
            model.ModelBuilder.DeleteEmployee(id);
            return RedirectToRoute(new { Area = "Admin", controller = "Employee", action = "Index" });
        }
        public IActionResult EmployeeReport(Guid id)
        {
            return View();
        }

        public IActionResult Profile(Guid id)
        {
            var model = new StudentFormViewModel();

            model = model.ModelBuilder.BuildStudentModel(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
    }
}
