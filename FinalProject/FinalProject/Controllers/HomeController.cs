using System;
using System.Collections.Generic;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Areas.Admin.Models;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new WebsiteModel
            {
                Header = new HeaderModel(),
                Footer = new FooterModel(),
                Advertise = new AdvertiseModel(),
                Notice = new NoticeModel(),
                Post = new PostModel()
            };
            return View(model);
        }
    }
}
