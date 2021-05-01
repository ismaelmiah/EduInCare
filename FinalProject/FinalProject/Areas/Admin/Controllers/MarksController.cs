using System;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
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
            var data = model.ModelBuilder.BuildStudentMarksList(academicYearId, courseId, sectionId, examId);
            if (data.Count == 0)
                return Json(data);
            return PartialView(data);
        }
        
        public IActionResult GetStudentsMarks(Guid academicYearId, Guid courseId, Guid sectionId, Guid examId)
        {
            var model = new MarksModel();
            var data = model.ModelBuilder.BuildStudentMarksList(academicYearId, courseId, sectionId, examId, true);
            return PartialView(data);
        }

        [HttpPost]
        public IActionResult AjaxMarkSave(StudentMarks studentMarks)
        {
            var model = new MarksModel();
            var isSaved = model.ModelBuilder.StudentMarkSave(studentMarks);
            return Json(new { success = isSaved });
        }

        public IActionResult GetMarksResult()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new MarksModel();
            var data = model.ModelBuilder.GetMarksResult(tableModel);
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
        
    }
}
