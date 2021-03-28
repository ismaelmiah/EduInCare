using System;
using System.Collections.Generic;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class CourseModel
    {
        internal CourseModelBuilder ModelBuilder;
        public CourseModel()
        {
            ModelBuilder = new CourseModelBuilder();
            DepartmentList = ModelBuilder.PopulateDepartmentsDropDownList();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public bool HaveCompulsorySubject { get; set; }
        public int MaxCompulsorySubject { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
        public SelectList DepartmentList { get; set; }
    }
}