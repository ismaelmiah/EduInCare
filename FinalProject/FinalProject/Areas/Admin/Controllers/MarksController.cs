using System;
using FinalProject.Web.Areas.Admin.Models;
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

        public IActionResult GetMarksResult()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new MarksModel();
            var data = model.ModelBuilder.GetMarksResult(tableModel);
            return Json(data);
        }
    }
}
