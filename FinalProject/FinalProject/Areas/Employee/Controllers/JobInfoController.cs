﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Employee.Models;
using FinalProject.Web.Models;

namespace FinalProject.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class JobInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(Guid? id)
        {
            var model = new JobInfoModel();
            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildEmployeeEducationModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(JobInfoModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    model.ModelBuilder.SaveEmployeeEducation(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateEmployeeEducation(model.Id, model);
                }
            }

            return RedirectToRoute(new { Area = "Admin", controller = "Employee", action = "Index" });
        }


        public IActionResult GetJobInfos()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new EmployeeModel();
            var data = model.GetJobInfos(tableModel);
            return Json(data);
        }
    }
}