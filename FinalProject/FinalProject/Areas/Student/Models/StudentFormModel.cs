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
        public Guid Id { get; set; }
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
        public string ImagePath { get; set; }
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
        public ParentsModel GetStudentParents(StudentParents model)
        {
            return new ParentsModel
            {
                FatherName = model.FatherName,
                FatherOccupation = model.FatherOccupation,
                FatherAnnualIncome = model.FatherAnnualIncome,
                FatherMobileNo = model.FatherMobileNo,
                MotherName = model.MotherName,
                MotherOccupation = model.FatherOccupation,
                MotherMobileNo = model.MotherMobileNo,
                GuardianName = model.GuardianName,
                GuardianMobileNo = model.GuardianMobileNo,
            };
        }
        public StudentParents GetStudentParents(ParentsModel model)
        {
            return new StudentParents
            {
                FatherName = model.FatherName,
                FatherOccupation = model.FatherOccupation,
                FatherAnnualIncome = model.FatherAnnualIncome,
                FatherMobileNo = model.FatherMobileNo,
                MotherName = model.MotherName,
                MotherOccupation = model.FatherOccupation,
                MotherMobileNo = model.MotherMobileNo,
                GuardianName = model.GuardianName,
                GuardianMobileNo = model.GuardianMobileNo,
            };
        }
        public Address GetActualAddress(AddressModel model) => new Address
        {
            City = model.City,
            Street = model.Street,
            ZipCode = model.ZipCode
        };
        public AddressModel GetActualAddress(Address model) => new AddressModel
        {
            City = model.City,
            Street = model.Street,
            ZipCode = model.ZipCode
        };
        public void DeleteStudent(Guid id)
        {
            _studentService.Delete(id);
        }
        public StudentFormModel GetStudentModel(Guid id)
        {
            var student = _studentService.GetStudent(id);
            return new StudentFormModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                Gender = student.Gender,
                DateOfBirth = student.DateOfBirth,
                YearOfEnroll = student.YearOfEnroll,
                Nationality = student.Nationality,
                MobileNo = student.MobileNo,
                BirthCertificateNo = student.BirthCertificateNo,
                NationalIdentificationNo = student.NationalIdentificationNo,
                ParentsInfo = GetStudentParents(student.ParentsInfo),
                EnrollCourse = CourseList(),
                ImagePath = FormatImageUrl(student.PhotoImage?.Url),
                PermanentAddress = GetActualAddress(student.PermanentAddress),
                PresentAddress = GetActualAddress(student.PresentAddress)
            };
        }

        public void UpdateStudent()
        {
            var model = _studentService.GetStudent(Id);
            model.FirstName = FirstName;
            model.MiddleName = MiddleName;
            model.LastName = LastName;
            model.Gender = Gender;
            model.MobileNo = MobileNo;
            model.PresentAddress = GetActualAddress(PresentAddress);
            model.PermanentAddress = GetActualAddress(PermanentAddress);
            model.Nationality = Nationality;
            model.YearOfEnroll = YearOfEnroll;
            model.ParentsInfo = GetStudentParents(ParentsInfo);
            model.EnrollCourse = GetSelectedCourse(CourseId);
            if (Photo != null)
            {
                var imageInfo = StoreFile(Photo);

                model.PhotoImage = new Image
                {
                    Url = imageInfo.filePath,
                    AlternativeText = $"{model.FirstName} Image"
                };
            }
            _studentService.Update(model);
        }
    }
}