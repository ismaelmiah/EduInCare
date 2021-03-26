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
    public class EmploymentHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new EmploymentHistoryModel();
            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildEmploymentHistoryModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(EmploymentHistoryModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveEmploymentHistoryModel(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateEmploymentHistoryModel(model.Id, model);
                }
            }

            return RedirectToRoute(new { Area = "Admin", controller = "Employee", action = "Index" });
        }

        public IActionResult GetEmploymentHistories()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new EmployeeModel();
            var data = model.GetEmploymentHistories(tableModel);
            return Json(data);
        }
    }
}
