using System;
using System.Collections.Generic;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarksController : Controller
    {
        public IActionResult Index()
        {
            var model = new MarksModel();
            return View(model);
        }

        public IActionResult MarksEntry(Guid academicYearId, Guid courseId, Guid sectionId, Guid examId)
        {
            var model = new MarksModel();
            var data = model.ModelBuilder.GetStudentsAndExamRules(academicYearId, courseId, sectionId, examId);
            if (data.Count == 0)
                return Json(data);
            return PartialView(data);
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new MarksModel();

            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildMarksModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MarksModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.Save(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.Update(model.Id, model);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var model = new MarksModel();
            model.ModelBuilder.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GenerateTableByExamId(Guid examId)
        {
            var model = new MarksModel();
            var data = model.ModelBuilder.GetExam(examId);
            return Json(data);
        }
        
        public IActionResult GetStudentsAndExamRules(Guid academicYearId, Guid courseId, Guid sectionId, Guid examId)
        {
            var model = new MarksModel();
            var data = model.ModelBuilder.GetStudentsAndExamRules(academicYearId, courseId, sectionId, examId);
            return RedirectToAction(nameof(MarksEntry), data);
        }

        [HttpPost]
        public IActionResult AjaxMarkSave(StudentMarks studentMarks)
        {
            var model = new MarksModel();
            var isSaved = model.ModelBuilder.StudentMarkSave(studentMarks);
            return Json(new { success = isSaved, message = "Saved Successfully" });
        }

        public IActionResult GetMarksResult()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new MarksModel();
            var data = model.ModelBuilder.GetMarksResult(tableModel);
            return Json(data);
        }

        public IActionResult GetAcademicYears()
        {
            var model = new RegistrationModel();
            var data = model.ModelBuilder.GetAcademicYearList();
            return Json(data);
        }
        public IActionResult GetCoursesByYear(Guid yearId)
        {
            var model = new RegistrationModel();
            var data = model.ModelBuilder.GetCourseList(yearId);
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
        public IActionResult GetSectionsByCourse(Guid courseId)
        {
            var model = new RegistrationModel();
            var data = model.ModelBuilder.GetSectionList(courseId);
            return Json(data);
        }

        public IActionResult GetStudents(Guid courseId, int shift)
        {
            var model = new RegistrationModel();
            var data = model.ModelBuilder.GetStudentList(courseId);
            return Json(data);
        }
    }
}
