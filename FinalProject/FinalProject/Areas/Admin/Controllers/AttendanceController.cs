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
            model.ModelBuilder.GetCourseList();
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

        public IActionResult GetStudents(Guid courseId)
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new StudentAttendanceModel();
            var data = model.ModelBuilder.GetStudentList(tableModel, courseId);
            return Json(data);
        }
    }
}
