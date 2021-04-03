using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Membership.Library.Contexts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Student.Models
{
    public class StudentModelBuilder : BaseModel
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IStudentParentService _parentService;
        private readonly IRegistrationStudentService _registration;
        private readonly IAcademicYearService _academic;
        private readonly ApplicationDbContext _dbContext;
        private readonly ISectionService _section;
        private readonly ISubjectService _subject;


        public StudentModelBuilder(IStudentService studentService, ICourseService courseService, IStudentParentService parentService, IRegistrationStudentService registration, IAcademicYearService academic, ApplicationDbContext dbContext, ISectionService section, ISubjectService subject)
        {
            _studentService = studentService;
            _courseService = courseService;
            _parentService = parentService;
            _registration = registration;
            _academic = academic;
            _dbContext = dbContext;
            _section = section;
            _subject = subject;
        }
        public StudentModelBuilder()
        {
            _parentService = Startup.AutofacContainer.Resolve<IStudentParentService>();
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _academic = Startup.AutofacContainer.Resolve<IAcademicYearService>();
            _registration = Startup.AutofacContainer.Resolve<IRegistrationStudentService>();
            _dbContext = Startup.AutofacContainer.Resolve<ApplicationDbContext>();
            _section = Startup.AutofacContainer.Resolve<ISectionService>();
            _subject = Startup.AutofacContainer.Resolve<ISubjectService>();
        }
        private Foundation.Library.Entities.Student ConvertToEntityStudent(StudentFormViewModel model)
        {
            var student = new Foundation.Library.Entities.Student();
            if (model.Photo != null)
            {
                StoreFile(model.Photo);
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
        public void DeleteStudent(Guid id)
        {
            _studentService.Delete(id);
        }

        public StudentProfileView BuildStudentProfileView(Guid id)
        {
            var student = _studentService.GetStudent(id);
            //var userInfo = _dbContext.Users.Find(student.UserId);
            var registrationInfo = _registration.GetRegistration(student.Registration.Id);
            var courseInfo = _courseService.GetCourse(registrationInfo.CourseId);
            var academicYear = _academic.GetAcademicYear(registrationInfo.AcademicYearId);
            var sectionInfo = _section.GetSection(registrationInfo.SectionId);

            return new StudentProfileView
            {
                Name = student.FirstName + " " + student.MiddleName + " " + student.LastName,
                Gender = student.Gender,
                DateOfBirth = student.DateOfBirth,
                YearOfEnroll = student.YearOfEnroll,
                Nationality = student.Nationality,
                MobileNo = student.MobileNo,
                BirthCertificateNo = student.BirthCertificateNo,
                NationalIdentificationNo = student.NationalIdentificationNo,
                ParentsInfo = GetStudentParents(student.Parents),
                ImagePath = FormatImageUrl(student.ImageUrl),
                Religion = student.Religion,
                BloodGroup = student.BloodGroup,
                //Email = userInfo.Email,
                //UserName = userInfo.UserName,
                PresentAddress = student.PresentAddress,
                PermanentAddress = student.PermanentAddress,
                AcademicYearModel = GetAcademicYearModel(academicYear),
                RegistrationModel = GetRegistrationModel(registrationInfo),
                CourseModel = GetCourseModel(courseInfo),
                SectionModel = GetSectionModel(sectionInfo),
                SubjectModels = GetSubjects(sectionInfo.CourseId)
            };
        }

        private List<SubjectModel> GetSubjects(Guid courseId)
        {

            return _subject.GetSubjects(courseId).Select(x => new SubjectModel
            {
                Name = x.Name,
                Code = x.Code,
                ExcludeInResult = x.ExcludeInResult,
                Type = x.Type
            }).ToList();
        }
        private static SectionModel GetSectionModel(Section x)
        {
            return new SectionModel
            {
                Name = x.Name,
                Capacity = x.Capacity,
                Status = x.Status,
                Description = x.Description
            };
        }
        private static CourseModel GetCourseModel(Foundation.Library.Entities.Course x)
        {
            return new CourseModel
            {
                Title = x.Name,
                Duration = x.Duration,
                HaveCompulsorySubject = x.HaveCompulsorySubject,
                MaxCompulsorySubject = x.MaxCompulsorySubject,
                Status = x.Status,
                Description = x.Description,
            };
        }
        private static AcademicYearModel GetAcademicYearModel(AcademicYear x)
        {
            return new AcademicYearModel
            {
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                IsOpenForAdmission = x.IsOpenForAdmission,
                Status = x.Status,
                Title = x.Title
            };
        }

        private static RegistrationModel GetRegistrationModel(Registration x)
        {
            return new RegistrationModel
            {
                BoardRegistrationNo = x.BoardRegistrationNo,
                IdCardNo = x.CardNo,
                IsPromoted = x.IsPromoted,
                Status = x.Status,
                Shift = x.Shift,
                RollNo = x.RollNo,
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

        public IList<SubjectModel> GetSubjectModels()
        {
            return _subject.GetSubjects().Select(x => new SubjectModel
            {
                Name = x.Name,
                Code = x.Code,
                ExcludeInResult = x.ExcludeInResult,
                Type = x.Type
            }).ToList();
        }
    }
}