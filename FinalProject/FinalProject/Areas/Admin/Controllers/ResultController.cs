using System.Collections.Generic;
using FinalProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResultController : Controller
    {
        public IActionResult Index()
        {
            var model = new StudentMarks()
            {
                StudentMark = new List<MarkDistribution>()
                {
                    new MarkDistribution {Name = "Writting", Mark = 3},
                    new MarkDistribution {Name = "Writting", Mark = 3}
                }
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(StudentMarks model, List<MarkDistribution> mark)
        {
            return View();
        }
    }
}