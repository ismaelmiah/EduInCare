using System;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Course.Controllers
{
    [Area("Course")]
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetRegisteredData()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new RegistrationModel();
            var data = model.ModelBuilder.GetRegisteredData(tableModel);
            return Json(data);
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new RegistrationModel();

            if (id == null)
                return PartialView(model);

            model = model.ModelBuilder.BuildRegistrationModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveRegistration(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateRegistration(model.Id, model);
                    return RedirectToAction(nameof(Index));
                }
            }

            return PartialView(model);
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

        public IActionResult GetSectionsByCourse(Guid courseId)
        {
            var model = new RegistrationModel();
            var data = model.ModelBuilder.GetSectionList(courseId);
            return Json(data);
        }

        public IActionResult GetStudents(Guid courseId)
        {
            var model = new RegistrationModel();
            var data = model.ModelBuilder.GetStudentList(courseId);
            return Json(data);
        }
        public IActionResult Delete(Guid id)
        {
            var model = new RegistrationModel();
            model.ModelBuilder.DeleteRegistration(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
