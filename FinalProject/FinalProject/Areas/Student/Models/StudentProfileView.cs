using System;
using System.Collections.Generic;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Areas.Student.Models.ModelBuilder;
using Foundation.Library.Enums;

namespace FinalProject.Web.Areas.Student.Models
{
    public class StudentProfileView
    {
        internal StudentModelBuilder ModelBuilder;
        public StudentProfileView()
        {
            ModelBuilder = new StudentModelBuilder();
        }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthCertificateNo { get; set; }
        public string NationalIdentificationNo { get; set; }
        public Gender Gender { get; set; }
        public Religion Religion { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Nationality { get; set; }
        public DateTime YearOfEnroll { get; set; }
        public ParentsModel ParentsInfo { get; set; }
        public string ImagePath { get; set; }
        public AcademicYearModel AcademicYearModel { get; set; }
        public RegistrationModel RegistrationModel { get; set; }
        public CourseModel CourseModel { get; set; }
        public SectionModel SectionModel { get; set; }
        public List<SubjectModel> SubjectModels { get; set; }
    }
}