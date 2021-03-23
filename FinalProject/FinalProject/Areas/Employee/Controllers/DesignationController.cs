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
    public class DesignationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new DesignationModel();
            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildDesignationModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(DesignationModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveDesignationModel(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateDesignationModel(model.Id, model);
                }
            }

            return RedirectToRoute(new { Area = "Admin", controller = "Employee", action = "Index" });
        }


        public IActionResult GetDesignations()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new EmployeeModel();
            var data = model.GetDesignations(tableModel);
            return Json(data);
        }
    }
}
