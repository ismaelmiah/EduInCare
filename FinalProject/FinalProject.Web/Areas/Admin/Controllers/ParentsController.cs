using FinalProject.Web.Areas.Student.Models;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ParentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetParents()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ParentsModel();
            var data = model.GetParents(tableModel);
            return Json(data);
        }
    }
}
