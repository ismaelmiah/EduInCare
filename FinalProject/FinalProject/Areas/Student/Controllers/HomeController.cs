﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert()
        {
            return View();
        }
        public IActionResult Delete(Guid id)
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult StudentReport(Guid id)
        {
            return View();
        }

        public IActionResult Profile(Guid id)
        {
            return View();
        }
    }
}