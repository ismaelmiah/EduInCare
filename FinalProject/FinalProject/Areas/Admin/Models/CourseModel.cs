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
            DepartmentList = ModelBuilder.GetDepartmentList();
            GroupList = ModelBuilder.GetGroupList();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public bool HaveCompulsorySubject { get; set; }
        public int MaxCompulsorySubject { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public Guid GroupId { get; set; }
        public List<SelectListItem> GroupList { get; set; }
    }
}