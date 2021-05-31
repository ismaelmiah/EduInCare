using Microsoft.AspNetCore.Mvc;
using System;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(policy: "AdminPolicy")]
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetDepartments()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new DepartmentModel();
            var data = model.GetDepartments(tableModel);
            return Json(data);
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new DepartmentModel();
            if (id == null)
                return PartialView(model);

            model = model.BuildModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.SaveDepartment();
                }
                else
                {
                    //Update
                    model.Update(model.Id, model);
                }
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(Guid id)
        {
            var model = new DepartmentModel();
            model.DeleteDepartment(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
