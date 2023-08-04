using System;
using System.ComponentModel.DataAnnotations;
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
            AcademicYearList = ModelBuilder.PopulateAcademicYearDropDownList();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public bool HaveCompulsorySubject { get; set; }
        public int MaxCompulsorySubject { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }
        public SelectList DepartmentList { get; set; }
        [Display(Name = "Academic Year")]
        [Required]
        public Guid AcademicYearId { get; set; }
        public SelectList AcademicYearList { get; set; }
    }
}