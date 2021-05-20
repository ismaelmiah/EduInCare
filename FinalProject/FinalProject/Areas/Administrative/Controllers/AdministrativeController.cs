using FinalProject.Web.Areas.Administrative.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Administrative.Controllers
{
    [Area("Administrative")]
    public class AdministrativeController : Controller
    {
        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult GetRoles()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new RoleModel();
            var data = model.ModelBuilder.GetRoles(tableModel);
            return Json(data);
        }

        public IActionResult DeleteRole(string id)
        {
            var model = new RoleModel();
            model.ModelBuilder.DeleteRole(id);
            return RedirectToAction(nameof(Roles));
        }

        public IActionResult UpsertRole(string id)
        {
            var model = new RoleModel();

            if (string.IsNullOrWhiteSpace(id))
                return View(model);

            model = model.ModelBuilder.BuildRoleModel(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    //Create
                    model.ModelBuilder.SaveRole(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateRole(model.Id, model);
                }
            }
            return RedirectToAction(nameof(Roles));
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}
