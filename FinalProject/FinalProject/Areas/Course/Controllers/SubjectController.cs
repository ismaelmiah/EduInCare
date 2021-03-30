using System;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Course.Controllers
{
    [Area("Course")]
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
                return View(model);

            model = model.ModelBuilder.BuildSubjectModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
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
            return RedirectToRoute(new { Area = "Course", controller = "Subject", action = "Index" });
        }


        public IActionResult Delete(Guid id)
        {
            var model = new SubjectModel();
            model.ModelBuilder.DeleteSubject(id);
            return RedirectToRoute(new { Area = "Course", controller = "Subject", action = "Index" });
        }
    }
}
