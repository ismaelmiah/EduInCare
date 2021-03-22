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
        private readonly IEducationLevelService _educationLevelService;
        private readonly IExamTitleService _examTitleService;
        internal EmployeeEducationModelBuilder ModelBuilder;
        public EmployeeEducationModel(IEmployeeService employee, IEducationLevelService educationLevelService, IExamTitleService examTitleService)
        {
            _employee = employee;
            _educationLevelService = educationLevelService;
            _examTitleService = examTitleService;
        }

        public EmployeeEducationModel()
        {
            _employee = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _educationLevelService = Startup.AutofacContainer.Resolve<IEducationLevelService>();
            _examTitleService = Startup.AutofacContainer.Resolve<IExamTitleService>();

            ModelBuilder = new EmployeeEducationModelBuilder();
            EducationLevelList = _educationLevelService.GetEducationLevels().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.EducationLevelName
            }).ToList();

            ExamTitleList = _examTitleService.ExamTitles().Select(x => new SelectListItem
            {
                Text = x.TitleName,
                Value = x.Id.ToString(),
            }).ToList();

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