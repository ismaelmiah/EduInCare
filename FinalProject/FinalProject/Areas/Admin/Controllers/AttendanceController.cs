using System;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
            var model = new StudentAttendanceModel();
            return View(model);
        }
        public IActionResult EmployeeAttendance()
        {
            return View();
        }

        public IActionResult GetSectionsByCourse(Guid courseId)
        {
            var model = new StudentAttendanceModel();
            var data = model.ModelBuilder.GetSectionList(courseId);
            return Json(data);
        }

        public IActionResult GetStudents(Guid courseId, Guid sectionId)
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new StudentAttendanceModel();
            var data = model.ModelBuilder.GetStudentList(tableModel, courseId, sectionId);
            return Json(data);
        }
    }
}
