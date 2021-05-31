using System;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(policy: "AdminPolicy")]
    public class AcademicYearController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAcademicYears()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new AcademicYearModel();
            var data = model.ModelBuilder.GetAcademicYears(tableModel);
            return Json(data);
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new AcademicYearModel();

            if (id == null)
                return PartialView(model);

            model = model.ModelBuilder.BuildAcademicYearModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(AcademicYearModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveAcademicYear(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateAcademicYear(model.Id, model);
                }
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(Guid id)
        {
            var model = new AcademicYearModel();
            model.ModelBuilder.DeleteAcademicYear(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
