using System;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GradeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new GradeModel();

            if (id == null)
                return PartialView(model);

            model = model.ModelBuilder.BuildGradeModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(GradeModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveGrade(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateGrade(model.Id, model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var model = new GradeModel();
            model.ModelBuilder.DeleteGrade(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetGrades()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new GradeModel();
            var data = model.ModelBuilder.GetGrades(tableModel);
            return Json(data);
        }
    }
}
