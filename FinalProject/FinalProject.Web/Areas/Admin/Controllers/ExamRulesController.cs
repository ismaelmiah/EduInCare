using System;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExamRulesController : Controller
    {
        public IActionResult Index()
        {
            var model = new ExamRulesModel();
            return View(model);
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new ExamRulesModel();

            if (id == null)
                return PartialView(model);

            model = model.ModelBuilder.BuildExamRulesModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ExamRulesModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveExamRules(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateExamRules(model.Id, model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var model = new ExamRulesModel();
            model.ModelBuilder.DeleteExamRules(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetExamRules(Guid courseId)
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ExamRulesModel();
            var data = model.ModelBuilder.GetExamRules(courseId, tableModel);
            return Json(data);
        }

        public IActionResult GetSubjects(Guid courseId)
        {
            var model = new ExamRulesModel();
            var data = model.ModelBuilder.GetSubjectList(courseId);
            return Json(data);
        }

        public IActionResult GetExams(Guid courseId)
        {
            var model = new ExamRulesModel();
            var data = model.ModelBuilder.GetExamList(courseId);
            return Json(data);
        }

        public IActionResult GetMarkDistributions(Guid examId)
        {
            var model = new ExamRulesModel();
            var data = model.ModelBuilder.GetMarksDistributions(examId);
            return Json(data);
        }
    }
}
