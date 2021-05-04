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

        public IActionResult MarksEntry(Guid academicYearId, Guid courseId, Guid subjectId, Guid sectionId, Guid examId, bool isMarkSet = false)
        {
            var model = new MarksModel();
            var (data, isPublished) = model.ModelBuilder.BuildStudentMarksList(academicYearId, courseId, subjectId, sectionId, examId, isMarkSet);
            
            if (isPublished == false)
                return Json(true);
            else if (data.Count == 0)
                return Json(data);
            return PartialView(data);
        }
        
        public IActionResult GetStudentsMarks(Guid academicYearId, Guid courseId, Guid subjectId, Guid sectionId, Guid examId)
        {
            var model = new MarksModel();
            var (data, isPublished) = model.ModelBuilder.BuildStudentMarksList(academicYearId, courseId, subjectId, sectionId, examId, true);
            //if (isPublished == false) return Json(true);
            return PartialView(data);
        }

        [HttpPost]
        public IActionResult AjaxMarkSave(StudentMarks studentMarks)
        {
            var model = new MarksModel();
            var isSaved = model.ModelBuilder.StudentMarkSave(studentMarks);
            return Json(new { success = isSaved });
        }

        public IActionResult GetResults(Guid academicYearId, Guid courseId, Guid sectionId, Guid examId)
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new MarksModel();
            var data = model.ModelBuilder.GetMarksResult(tableModel, academicYearId, courseId, sectionId, examId);
            return Json(data);
        }

        public IActionResult Results() =>  View();

        public IActionResult PublishResult(Guid academicYearId, Guid courseId, Guid subjectId, Guid sectionId, Guid examId)
        {
            var model = new MarksModel();
            var isPublished = model.ModelBuilder.PublishResult(academicYearId, courseId, subjectId, sectionId, examId);
            return Json(isPublished);
        }

        public IActionResult GetAcademicYears()
        {
            var model = new MarksModel();
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
        
    }
}
