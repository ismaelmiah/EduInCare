using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Student.Models
{
    public class StudentModelBuilder : BaseModel
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IStudentParentService _parentService;

        public StudentModelBuilder(IStudentService studentService, ICourseService courseService,
            IStudentParentService parentService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _parentService = parentService;
        }
        public StudentModelBuilder()
        {
            _parentService = Startup.AutofacContainer.Resolve<IStudentParentService>();
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        private Foundation.Library.Entities.Student ConvertToEntityStudent(StudentFormViewModel model)
        {
            var student = new Foundation.Library.Entities.Student();
            if (model.Photo != null)
            {
                var imageInfo = StoreFile(model.Photo);
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

            return student;
        }

        public List<SelectListItem> CourseList()
        {
            var data = _courseService.GetCourses();
            return data.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
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

        public Parents GetParentsChanges(ParentsModel model)
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

        public AddressModel BuildAddressModel(string address)
        {
            var fullAddress = address.Split(",");
            var addressModel = new AddressModel
            {
                City = fullAddress[1],
                Street = fullAddress[0],
                ZipCode = fullAddress[2]
            };
            return addressModel;
        }
        public void DeleteStudent(Guid id)
        {
            _studentService.Delete(id);
        }

        public StudentProfileView BuildStudentProfileView(Guid id)
        {
            var student = _studentService.GetStudent(id);
            return new StudentProfileView
            {
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
                ImagePath = FormatImageUrl(student.ImageUrl)
            };
        }
        public StudentFormViewModel BuildStudentModel(Guid id)
        {
            var student = _studentService.GetStudent(id);
            return new StudentFormViewModel
            {
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
                ImagePath = "",
            };
        }

        public void UpdateStudent(Guid id, StudentFormViewModel model)
        {
            var exStudent = _studentService.GetStudent(id);

            exStudent.FirstName = model.FirstName;
            exStudent.MiddleName = model.MiddleName;
            exStudent.LastName = model.LastName;
            exStudent.Gender = model.Gender;
            exStudent.MobileNo = model.MobileNo;
            exStudent.Nationality = model.Nationality;
            exStudent.YearOfEnroll = model.YearOfEnroll;
            exStudent.Parents = GetParentsChanges(model.ParentsInfo);
            if (model.Photo != null)
            {
                var imageInfo = StoreFile(model.Photo);
            }
            _studentService.Update(exStudent);
        }
        
        public void SaveStudent(StudentFormViewModel model)
        {
            var student = ConvertToEntityStudent(model);
            _studentService.AddStudent(student);
        }
    }
}