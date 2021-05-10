using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Web.Areas.Administrative.Models;

namespace FinalProject.Web.Areas.Administrative.Controllers
{
    [Area("Administrative")]
    public class WebsiteController : Controller
    {
        public IActionResult Homepage()
        {
            var model = new HomePageModel()
            {
                Sliders = new List<SliderModel>()
                {
                    new SliderModel()
                    {
                        Heading = "",
                        SubHeading = ""
                    }
                }
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Homepage(HomePageModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Save Homepage Data Into Database
            }
            return View(model);
        }
    }
}
