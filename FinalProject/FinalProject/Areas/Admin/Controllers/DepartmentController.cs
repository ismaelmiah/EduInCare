using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Models;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult Upsert()
        {
            var model = new DepartmentModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Upsert(DepartmentModel model)
        {
            model.SaveDepartment();
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
