using System;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Course.Controllers
{
    [Area("Course")]
    [Authorize(policy: "AdminPolicy")]
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetSubjects()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new SubjectModel();
            var data = model.ModelBuilder.GetSubjects(tableModel);
            return Json(data);
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new SubjectModel();

            if (id == null)
                return PartialView(model);

            model = model.ModelBuilder.BuildSubjectModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveSubject(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateSubject(model.Id, model);
                }
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(Guid id)
        {
            var model = new SubjectModel();
            model.ModelBuilder.DeleteSubject(id);
            return RedirectToRoute(new { Area = "Course", controller = "Subject", action = "Index" });
        }
    }
}
