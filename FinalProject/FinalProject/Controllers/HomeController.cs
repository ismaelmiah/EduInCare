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
                Header = new HeaderModel().CurrentHeader(),
                Footer = new FooterModel(),
                Advertise = new AdvertiseModel(),
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
                Post = new PostModel
                {
                    PostList = new List<PostViewModel>
                    {
                        new PostViewModel
                        {
                            Title = "Admission",
                            CreateDate = DateTime.Today,
                            Description = "Admission Going On"
                        },
                        new PostViewModel
                        {
                            Title = "Admission",
                            CreateDate = DateTime.Today,
                            Description = "Admission Going On"
                        },
                    }
                }
            };
            return View(model);
        }
    }
}
