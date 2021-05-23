using System;
using System.ComponentModel.DataAnnotations;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class StudentAttendanceModel
    {
        internal AttendanceModelBuilder ModelBuilder;
        public StudentAttendanceModel()
        {
            ModelBuilder = new AttendanceModelBuilder();
            CourseList = ModelBuilder.GetCourseList();
        }
        [Display(Name = "Course")]
        public Guid CourseId { get; set; }
        public SelectList CourseList { get; set; }
        [Display(Name = "Section")]
        public Guid SectionId { get; set; }
        public SelectList SectionList { get; set; }
    }

    public class Attendance
    {
        public string StudentName { get; set; }
        public string RegistrationNo { get; set; }
        public int RollNo { get; set; }
        public bool IsPresent { get; set; }
    }
}