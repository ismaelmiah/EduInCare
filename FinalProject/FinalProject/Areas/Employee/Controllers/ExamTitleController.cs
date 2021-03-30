using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;
using FinalProject.Web.Areas.Employee.Models;
using FinalProject.Web.Areas.Employee.Models.ModelBuilder;
using FinalProject.Web.Models;

namespace FinalProject.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ExamTitleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(Guid? id)
        {
            var model = new ExamModel();
            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildExamModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ExamModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveExamModel(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateExamModel(model.Id, model);
                }
            }

            return RedirectToRoute(new { Area = "Admin", controller = "Employee", action = "Index" });
        }
        public IActionResult GetExamTitles()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new EmployeeModelBuilder();
            var data = model.GetExamTitles(tableModel);
            return Json(data);
        }
    }
}
