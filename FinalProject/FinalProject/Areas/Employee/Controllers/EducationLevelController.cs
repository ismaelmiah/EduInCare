using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Employee.Models;
using FinalProject.Web.Models;

namespace FinalProject.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EducationLevelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(Guid? id)
        {
            var model = new EducationLevelModel();
            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildEducationLevelModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(EducationLevelModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveEducationLevelModel(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateEducationLevelModel(model.Id, model);
                }
            }

            return RedirectToRoute(new { Area = "Admin", controller = "Employee", action = "Index" });
        }
        public IActionResult GetEducationLevels()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new EmployeeModel();
            var data = model.GetEducationLevels(tableModel);
            return Json(data);
        }
    }
}
