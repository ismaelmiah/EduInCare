using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Enums;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Student.Models.ModelBuilder
{
    public class StudentModelBuilder : BaseModel
    {
        private readonly IApplicantService _applicantService;
        private readonly ICourseService _courseService;
        private readonly IRegistrationStudentService _registration;
        private readonly IAcademicYearService _academic;
        private readonly ISectionService _section;
        private readonly ISubjectService _subject;
        private readonly IStudentService _studentService;


        public StudentModelBuilder(IApplicantService applicantService, ICourseService courseService, IRegistrationStudentService registration, IAcademicYearService academic, ISectionService section, ISubjectService subject, IStudentService studentService)
        {
            _applicantService = applicantService;
            _courseService = courseService;
            _registration = registration;
            _academic = academic;
            _section = section;
            _subject = subject;
            _studentService = studentService;
        }
        public StudentModelBuilder()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
            _applicantService = Startup.AutofacContainer.Resolve<IApplicantService>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _academic = Startup.AutofacContainer.Resolve<IAcademicYearService>();
            _registration = Startup.AutofacContainer.Resolve<IRegistrationStudentService>();
            _section = Startup.AutofacContainer.Resolve<ISectionService>();
            _subject = Startup.AutofacContainer.Resolve<ISubjectService>();
        }
        public StudentProfileView BuildStudentProfileView(Guid id)
        {
            var student = _studentService.GetStudent(id);
            //var userInfo = _dbContext.Users.Find(student.UserId);
            //var registrationInfo = _registration.GetRegistrations().FirstOrDefault(x => x.StudentId == student.Id);
            var courseInfo = _courseService.GetCourse(student.CourseId);
            //var academicYear = _academic.GetAcademicYear(registrationInfo.AcademicYearId);
            //var sectionInfo = _section.GetSection(registrationInfo.SectionId);

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
                //ParentsInfo = GetParentsModel(student.Parents),
                ImagePath = FormatImageUrl(student.ImageUrl),
                Religion = student.Religion,
                BloodGroup = student.BloodGroup,
                //Email = userInfo.Email,
                //UserName = userInfo.UserName,
                PresentAddress = student.PresentAddress,
                PermanentAddress = student.PermanentAddress,
                //AcademicYearModel = GetAcademicYearModel(academicYear),
                //RegistrationModel = GetRegistrationModel(registrationInfo),
                CourseModel = GetCourseModel(courseInfo),
                //SectionModel = GetSectionModel(sectionInfo),
                SubjectModels = GetSubjects(courseInfo.Id)
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
                RollNo = x.RollNo,
            };
        }


        public ParentsModel GetParentsModel(Parents model)
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

        public Parents GetParentsEntity(ParentsModel model)
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

    }
}