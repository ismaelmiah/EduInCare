using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Foundation.Library.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class ExamModel
    {
        private readonly IEducationLevelRepository _educationLevel;
        internal ExamModelBuilder ModelBuilder;

        public ExamModel(IEducationLevelRepository educationLevel)
        {
            _educationLevel = educationLevel;
        }
        public ExamModel()
        {
            _educationLevel = Startup.AutofacContainer.Resolve<IEducationLevelRepository>();
            ModelBuilder = new ExamModelBuilder();
            EducationLevelList = _educationLevel.GetAll().Select(x => new SelectListItem
            {
                Text = x.EducationLevelName,
                Value = x.Id.ToString()
            }).ToList();
        }

        public Guid Id { get; set; }
        public string ExamTitle { get; set; }
        public Guid EducationLevelId { get; set; }
        public IList<SelectListItem> EducationLevelList { get; set; }
    }
}