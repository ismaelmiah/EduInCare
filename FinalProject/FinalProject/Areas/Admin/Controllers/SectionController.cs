using System;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new SectionModel();

            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildSectionModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SectionModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveSection(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateSection(model.Id, model);
                }
            }
            return RedirectToRoute(new { Area = "Admin", controller = "Section", action = "Index" });
        }

        public IActionResult Delete(Guid id)
        {
            var model = new SectionModel();
            model.ModelBuilder.DeleteSection(id);
            return RedirectToRoute(new { Area = "Admin", controller = "Section", action = "Index" });
        }
        public IActionResult GetSections()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new SectionModel();
            var data = model.ModelBuilder.GetSections(tableModel);
            return Json(data);
        }
    }
}
