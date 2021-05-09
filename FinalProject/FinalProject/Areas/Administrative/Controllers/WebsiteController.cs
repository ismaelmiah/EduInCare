using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Web.Areas.Administrative.Models;

namespace FinalProject.Web.Areas.Administrative.Controllers
{
    [Area("Administrative")]
    public class WebsiteController : Controller
    {
        public IActionResult Slider()
        {
            var model = new SliderModel();
            return View(model);
        }
    }
}
