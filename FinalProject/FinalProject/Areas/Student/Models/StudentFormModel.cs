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
        private readonly IStudentParentService _parentService;

        public StudentFormModel(IStudentService studentService, ICourseService courseService,
            IStudentParentService parentService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _parentService = parentService;
        }

        public StudentFormModel()
        {
            _parentService = Startup.AutofacContainer.Resolve<IStudentParentService>();
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

            var student = new Foundation.Library.Entities.Student();
            if (Photo != null)
            {
                var imageInfo = StoreFile(model.Photo);
                student.Image = new Image
                {
                    Url = imageInfo.filePath,
                    AlternativeText = $"{model.FirstName} Image"
                };
            }

            student.FirstName = model.FirstName;
            student.MiddleName = model.MiddleName;
            student.LastName = model.LastName;
            student.Gender = model.Gender;
            student.DateOfBirth = model.DateOfBirth;
            student.YearOfEnroll = model.YearOfEnroll;
            student.Nationality = model.Nationality;
            student.BirthCertificateNo = model.BirthCertificateNo;
            student.NationalIdentificationNo = model.NationalIdentificationNo;
            student.Parents = new Parents()
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
            };
            student.Course = GetSelectedCourse(model.CourseId);
            student.Address = GetActualAddress(model.PermanentAddress);

            return student;
        }

        public Course GetSelectedCourse(Guid id)
        {
            return _courseService.GetCourse(id);
        }
        public ParentsModel GetStudentParents(Parents model)
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
        public void GetParentsChanges(ParentsModel model, Parents exParents)
        {
            exParents.FatherName = model.FatherName;
            exParents.FatherOccupation = model.FatherOccupation;
            exParents.FatherAnnualIncome = model.FatherAnnualIncome;
            exParents.FatherMobileNo = model.FatherMobileNo;
            exParents.MotherName = model.MotherName;
            exParents.MotherOccupation = model.FatherOccupation;
            exParents.MotherMobileNo = model.MotherMobileNo;
            exParents.GuardianName = model.GuardianName;
            exParents.GuardianMobileNo = model.GuardianMobileNo;
        }

        public void GetAddressChanges(AddressModel model, Address exAddress)
        {
            exAddress.PresentAddress = model.Street + " " + model.City + " " + model.ZipCode;
            exAddress.PermanentAddress = model.Street + " " + model.City + " " + model.ZipCode;
        }
        public Parents GetStudentParents(ParentsModel model)
        {
            return new Parents
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
            PresentAddress = model.City,
            PermanentAddress = model.Street,
        };
        public AddressModel GetActualAddress(Address model) => new AddressModel
        {
            City = model.PresentAddress,
            Street = model.PermanentAddress,
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
                ParentsInfo = GetStudentParents(student.Parents),
                EnrollCourse = CourseList(),
                ImagePath = FormatImageUrl(student.Image?.Url),
                PermanentAddress = GetActualAddress(student.Address),
            };
        }

        public void UpdateStudent()
        {
            var exStudent = _studentService.GetStudent(Id);
            
            exStudent.FirstName = FirstName;
            exStudent.MiddleName = MiddleName;
            exStudent.LastName = LastName;
            exStudent.Gender = Gender;
            exStudent.MobileNo = MobileNo;
            exStudent.Address = GetActualAddress(PresentAddress);
            exStudent.Nationality = Nationality;
            exStudent.YearOfEnroll = YearOfEnroll;
            exStudent.Parents = GetStudentParents(ParentsInfo);
            exStudent.Course = GetSelectedCourse(CourseId);
            if (Photo != null)
            {
                var imageInfo = StoreFile(Photo);

                exStudent.Image = new Image
                {
                    Url = imageInfo.filePath,
                    AlternativeText = $"{exStudent.FirstName} Image"
                };
            }

            //TODO: Implement Address Service & Course Service for Update Data
            
            _studentService.Update(exStudent);
        }
    }
}