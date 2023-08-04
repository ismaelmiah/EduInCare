using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class ExamModel
    {
        internal ExamModelBuilder ModelBuilder;
        public ExamModel()
        {
            ModelBuilder = new ExamModelBuilder();
            CourseList = ModelBuilder.GetCourseList();
            MarksDistributionTypeList = ModelBuilder.GetMarksDistributionTypes();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Marks Distribution")]
        public IList<int> MarksDistributionTypes { get; set; }
        public List<SelectListItem> MarksDistributionTypeList { get; set; }
        public bool Status { get; set; }
        public Guid CourseId { get; set; }
        public string Course { get; set; }
        public SelectList CourseList { get; set; }
    }
}