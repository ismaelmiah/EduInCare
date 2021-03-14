using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Autofac;
using FinalProject.Models;
using Foundation.Library.Services;
using Foundation.Library.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Student.Models
{
    public class StudentFormModel : BaseModel
    {

        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentFormModel(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        public StudentFormModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            EnrollCourse = CourseList();
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

        public IList<SelectListItem> EnrollCourse { get; set; }
        public Guid CourseId { get; set; }

        public void SaveStudent()
        {
            _studentService.AddStudent(ConvertToEntityStudent(this));
        }

        public List<SelectListItem> CourseList()
        {
            var data = _courseService.GetCourses();
            return data.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();
        }
        private Foundation.Library.Entities.Student ConvertToEntityStudent(StudentFormModel model)
        {
            var imageInfo = StoreFile(model.Photo);

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
                },
                EnrollCourse = GetSelectedCourse(model.CourseId),
                PhotoImage = new Image
                {
                    Url = imageInfo.filePath,
                    AlternativeText = $"{model.FirstName} Image"
                },
                PermanentAddress = GetActualAddress(model.PermanentAddress),
                PresentAddress = GetActualAddress(model.PresentAddress)
            };
        }

        public Course GetSelectedCourse(Guid id)
        {
            return _courseService.GetCourse(id);
        }

        public Address GetActualAddress(AddressModel model) => new Address
        {
            City = model.City,
            Street = model.Street,
            ZipCode = model.ZipCode
        };
        public void DeleteStudent(Guid id)
        {
            _studentService.Delete(id);
        }
    }
}