using System;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExamController : Controller
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
                    model.ModelBuilder.SaveExam(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateExam(model.Id, model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var model = new ExamModel();
            model.ModelBuilder.DeleteExam(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetExams()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ExamModel();
            var data = model.ModelBuilder.GetExams(tableModel);
            return Json(data);
        }
    }
}
