using System;
using FinalProject.Web.Areas.Student.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(policy: "AdminPolicy")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Upsert(Guid? id)
        {
            var model = new ApplicantViewModel();

            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildApplicantModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ApplicantViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveApplicant(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateApplicant(model.Id, model);
                }
            }
            return RedirectToRoute(new { Area = "", controller = "Home", action = "Index" });
        }

        public IActionResult Delete(Guid id)
        {
            var model = new ApplicantViewModel();
            model.ModelBuilder.DeleteApplication(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult StudentReport(Guid id)
        {
            return View();
        }

        public IActionResult GetSubjectsByCourse(Guid courseId)
        {
            var model = new ApplicantViewModel();
            var data = model.ModelBuilder.GetSubjectModels(courseId);
            return Json(data);
        }


        public IActionResult GetApplicants()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ApplicantViewModel();
            var data = model.ModelBuilder.GetApplicants(tableModel);
            return Json(data);
        }

        public IActionResult Profile(Guid id)
        {
            var model = new StudentProfileView();

            model = model.ModelBuilder.BuildStudentProfileView(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        public IActionResult Reject(ApplicationUpdateModel model)
        {
            model.RejectApplication();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Approve(ApplicationUpdateModel model)
        {
            try
            {
                model.ApproveApplication();
            }
            catch
            {
                // ignored
                model.RejectApplication();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult _ApplicationDetails(Guid id)
        {
            var model = new ApplicationViewModel();
            model.Applicants = model.ModelBuilder.GetRequestForApplicationDetails(id);

            return PartialView(model.Applicants);
        }
    }
}
