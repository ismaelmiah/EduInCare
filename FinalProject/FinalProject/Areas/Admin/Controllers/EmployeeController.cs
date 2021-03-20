using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetEmployees()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new EmployeeModel();
            var data = model.GetEmployees(tableModel);
            return Json(data);
        }
        public IActionResult GetTeachers()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new EmployeeModel();
            var data = model.GetTeachers(tableModel);
            return Json(data);
        }
    }
}
