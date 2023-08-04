using System;
using System.ComponentModel.DataAnnotations;
using FinalProject.Web.Areas.Course.Models.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Course.Models
{
    public class SubjectModel
    {
        internal SubjectModelBuilder ModelBuilder;
        public SubjectModel()
        {
            ModelBuilder = new SubjectModelBuilder();
            CourseList = ModelBuilder.GetCourseList();

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [Display(Name = "Core")]
        public bool Type { get; set; }
        public Guid CourseId { get; set; }
        public SelectList CourseList { get; set; }
        [Display(Name = "Exclude In Result")]
        public bool ExcludeInResult { get; set; }
    }
}