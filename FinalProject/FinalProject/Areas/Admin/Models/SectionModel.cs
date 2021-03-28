using System;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class SectionModel
    {
        internal SectionModelBuilder ModelBuilder;

        public SectionModel()
        {
            ModelBuilder = new SectionModelBuilder();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Guid CourseId { get; set; }
        public SelectList CourseList { get; set; }
        public Guid TeacherId { get; set; }
        public SelectList TeacherList { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}