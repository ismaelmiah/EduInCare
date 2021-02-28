﻿using System;
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
                Header = new HeaderModel().CurrentHeader(),
                Footer = new FooterModel().CurrentFooter(),
                Advertise = new AdvertiseModel().CurrentAdvertise(),
                Notice = new NoticeModel()
                {
                    NoticeList = new List<NoticeViewModel>
                    {
                        new NoticeViewModel()
                        {
                            Title = "Admission",
                            Description = "Admission Going On"
                        },
                        new NoticeViewModel()
                        {
                            Title = "Result Published",
                            Description = "Result Published On"
                        }
                    }
                },
                Post = new PostModel()
            };
            return View(model);
        }
    }
}
