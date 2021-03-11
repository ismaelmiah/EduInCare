using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
