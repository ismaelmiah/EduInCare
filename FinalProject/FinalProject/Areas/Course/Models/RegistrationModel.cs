using System;
using FinalProject.Web.Areas.Course.Models.ModelBuilder;
using Foundation.Library.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Course.Models
{
    public class RegistrationModel
    {
        internal RegistrationModelBuilder ModelBuilder;
        public RegistrationModel()
        {
            ModelBuilder = new RegistrationModelBuilder();
            StudentList = ModelBuilder.GetStudentList();
            CourseList = ModelBuilder.GetCourseList();
            SectionList = ModelBuilder.GetSectionList();
            AcademicYearList = ModelBuilder.GetAcademicYearList();
        }

        public Guid Id { get; set; }
        public string RegistrationNo { get; set; }
        public Guid StudentId { get; set; }
        public SelectList StudentList { get; set; }
        public Guid CourseId { get; set; }
        public SelectList CourseList { get; set; }
        public Guid SectionId { get; set; }
        public SelectList SectionList { get; set; }
        public Guid AcademicYearId { get; set; }
        public SelectList AcademicYearList { get; set; }
        public ShiftType Shift { get; set; }
        public int RollNo { get; set; }
        public string IdCardNo { get; set; }
        public string BoardRegistrationNo { get; set; }
        public bool IsPromoted { get; set; }
        public string OldRegistrationId { get; set; }
        public bool Status { get; set; }
    }
}