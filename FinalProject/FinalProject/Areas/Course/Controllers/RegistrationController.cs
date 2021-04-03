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
                return View(model);

            model = model.ModelBuilder.BuildRegistrationModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
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
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateRegistration(model.Id, model);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetAcademicYears()
        {
            var model = new RegistrationModel();
            var data = model.ModelBuilder.GetAcademicYearList();
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
