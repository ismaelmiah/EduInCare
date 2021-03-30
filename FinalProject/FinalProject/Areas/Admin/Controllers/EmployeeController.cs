using FinalProject.Web.Areas.Admin.Models.ModelBuilder;
using FinalProject.Web.Areas.Employee.Models;
using FinalProject.Web.Areas.Employee.Models.ModelBuilder;
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

        public IActionResult Employees()
        {
            return View();
        }
        public IActionResult Teachers()
        {
            return View();
        }
        public IActionResult GetEmployees()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new EmployeeFormViewModel();
            var data = model.ModelBuilder.GetEmployees(tableModel);
            return Json(data);
        }
        public IActionResult GetTeachers()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new EmployeeFormViewModel();
            var data = model.ModelBuilder.GetTeachers(tableModel);
            return Json(data);
        }
    }
}
