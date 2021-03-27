using System;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(Guid? id)
        {
            var model = new GroupModel();

            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildGroupModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(GroupModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveGroup(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateGroup(model.Id, model);
                }
            }
            return RedirectToRoute(new { Area = "", controller = "Home", action = "Index" });
        }

        public IActionResult Delete(Guid id)
        {
            var model = new GroupModel();
            model.ModelBuilder.DeleteGroup(id);
            return RedirectToRoute(new { Area = "Admin", controller = "Student", action = "Index" });
        }
        public IActionResult GetGroups()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new GroupModel();
            var data = model.ModelBuilder.GetGroups(tableModel);
            return Json(data);
        }
    }
}
