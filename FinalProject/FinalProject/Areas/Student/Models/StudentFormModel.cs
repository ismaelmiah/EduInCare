using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Autofac;
using Foundation.Library.Services;
using Foundation.Library.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Student.Models
{
    public class StudentFormModel
    {

        private readonly IStudentService _studentService;

        public StudentFormModel(IStudentService studentService) { _studentService = studentService; }

        public StudentFormModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
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
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        [Display(Name = "Present Address")]
        public AddressModel PresentAddress { get; set; }
        [Display(Name = "Permanent Address")]
        public AddressModel PermanentAddress { get; set; }
        public string Nationality { get; set; }
        [Display(Name = "Year Of Enroll")]
        public DateTime YearOfEnroll { get; set; }
        [Display(Name = "Parents Information")]
        public ParentsModel ParentsInfo { get; set; }

        public IFormFile Photo { get; set; }

        public IList<SelectListItem> EnrollCourse { get; set; } = new List<SelectListItem>
        {
            new SelectListItem()
            {
                Text = "Select Course",
                Value = "1"
            }
        };
        public Guid CourseId { get; set; }

        public void SaveStudent()
        {
            _studentService.CreateStudent(ConvertToEntityStudent(this));
        }

        public static Foundation.Library.Entities.Student ConvertToEntityStudent(StudentFormModel model)
        {
            return new Foundation.Library.Entities.Student
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                YearOfEnroll = model.YearOfEnroll,
                Nationality = model.Nationality,
                BirthCertificateNo = model.BirthCertificateNo,
                NationalIdentificationNo = model.NationalIdentificationNo,
                ParentsInfo = new StudentParents()
                {
                    FatherName = model.ParentsInfo.FatherName,
                    FatherOccupation = model.ParentsInfo.FatherOccupation,
                    FatherAnnualIncome = model.ParentsInfo.FatherAnnualIncome,
                    FatherMobileNo = model.ParentsInfo.FatherMobileNo,
                    MotherName = model.ParentsInfo.MotherName,
                    MotherOccupation = model.ParentsInfo.FatherOccupation,
                    MotherMobileNo = model.ParentsInfo.MotherMobileNo,
                    GuardianName = model.ParentsInfo.GuardianName,
                    GuardianMobileNo = model.ParentsInfo.GuardianMobileNo,
                }
            };
        }

        public void DeleteStudent(Guid id)
        {
            _studentService.Delete(id);
        }
    }
}