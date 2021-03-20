using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            if (ModelState.IsValid)
            {
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
            }
            return RedirectToRoute(new { Area = "Employee", controller = "Employee", action = "Index" });
        }

        public IActionResult Delete(Guid id)
        {
            var model = new StudentFormViewModel();
            model._modelBuilder.DeleteStudent(id);
            return RedirectToRoute(new { Area = "Admin", controller = "Student", action = "Index" });
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
