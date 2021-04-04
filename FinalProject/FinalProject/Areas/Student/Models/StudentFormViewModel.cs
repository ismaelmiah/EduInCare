using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FinalProject.Web.Areas.Course.Models;
using Foundation.Library.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Student.Models
{
    public class StudentFormViewModel
    {
        internal StudentModelBuilder ModelBuilder;
        public StudentFormViewModel()
        {
            ModelBuilder = new StudentModelBuilder();
            EnrollCourse = ModelBuilder.CourseList();
        }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Birth Certificate Number")]
        public string BirthCertificateNo { get; set; }
        [Display(Name = "National Identification Number")]
        public string NationalIdentificationNo { get; set; }
        public Gender Gender { get; set; }
        public Religion Religion { get; set; }
        public ShiftType Shift { get; set; }
        public string MobileNo { get; set; }
        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }
        public string Nationality { get; set; }
        [Display(Name = "Year Of Enroll")]
        public DateTime YearOfEnroll { get; set; }
        [Display(Name = "Parents Information")]
        public ParentsModel ParentsInfo { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Photo { get; set; }
        public IList<SelectListItem> EnrollCourse { get; set; }
        public Guid CourseId { get; set; }
        public Guid Id { get; set; }
        public IList<SubjectModel> SubjectModels { get; set; }
    }
}