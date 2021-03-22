using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Enums;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class EmployeeEducationModel
    {
        private readonly IEmployeeService _employee;
        internal EmployeeEducationModelBuilder ModelBuilder;
        public EmployeeEducationModel(IEmployeeService employee)
        {
            _employee = employee;
        }

        public EmployeeEducationModel()
        {
            _employee = Startup.AutofacContainer.Resolve<IEmployeeService>();
            ModelBuilder = new EmployeeEducationModelBuilder();
            EducationLevelList = new List<SelectListItem>
            {
                new SelectListItem{Text = "HSC", Value = "HSC"},
                new SelectListItem{Text = "SSC", Value = "SSC"},
                new SelectListItem{Text = "Degree", Value = "Degree"},
                new SelectListItem{Text = "BSC", Value = "BSC"},
                new SelectListItem{Text = "MSC", Value = "MSC"},
            };

            ExamTitleList = new List<SelectListItem>
            {
                new SelectListItem{Text = "MidTerm", Value = "MidTerm"},
                new SelectListItem{Text = "Final", Value = "Final"},
            };

            EmployeeList = _employee.GetAllEmployees().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }

        public Guid Id { get; set; }
        public Guid EducationLevelId { get; set; }
        public IList<SelectListItem> EducationLevelList { get; set; }
        public Guid ExamTitleId { get; set; }
        public IList<SelectListItem> ExamTitleList { get; set; }
        public string Major { get; set; }
        public string InstituteName { get; set; }
        public ResultType ResultType { get; set; }
        public float Cgpa { get; set; }
        public int Scale { get; set; }
        public float Marks { get; set; }
        public string PassingYear { get; set; }
        public int Duration { get; set; }
        public string Achievement { get; set; }
        public Guid EmployeeId { get; set; }
        public IList<SelectListItem> EmployeeList { get; set; }
    }
}