using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Enums;
using Foundation.Library.Services;
using Membership.Library.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Student.Models.ModelBuilder
{
    public class ApplicantModelBuilder : BaseModel
    {
        private readonly IApplicantService _applicantService;
        private readonly ICourseService _courseService;
        private readonly ISubjectService _subjectService;
        private readonly IStudentService _studentService;
        private readonly UserManager<ApplicationUser> _userManager;

        private const string DefaultPassword = "Test@123";

        public ApplicantModelBuilder(IApplicantService applicantService,
            ICourseService courseService,
            ISubjectService subject,
            IStudentService student, UserManager<ApplicationUser> userManager)
        {
            _applicantService = applicantService;
            _courseService = courseService;
            _subjectService = subject;
            _studentService = student;
            _userManager = userManager;
        }
        public ApplicantModelBuilder()
        {
            _userManager = Startup.AutofacContainer.Resolve<UserManager<ApplicationUser>>();
            _applicantService = Startup.AutofacContainer.Resolve<IApplicantService>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _subjectService = Startup.AutofacContainer.Resolve<ISubjectService>();
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }

        private Applicants ConvertToEntityApplicant(ApplicantViewModel model)
        {
            var applicant = new Applicants();
            if (model.Photo != null)
            {
                var (fileName, filePath) = StoreFile(model.Photo);
                applicant.ImageUrl = filePath;
                applicant.ImageAlternativeText = fileName;
            }

            applicant.FirstName = model.FirstName;
            applicant.MiddleName = model.MiddleName;
            applicant.LastName = model.LastName;
            applicant.Gender = model.Gender;
            applicant.DateOfBirth = model.DateOfBirth;
            applicant.Nationality = model.Nationality;
            applicant.BirthCertificateNo = model.BirthCertificateNo;
            applicant.NationalIdentificationNo = model.NationalIdentificationNo;
            applicant.BloodGroup = model.BloodGroup;
            applicant.CourseId = model.CourseId;
            applicant.PresentAddress = model.PresentAddress;
            applicant.MobileNo = model.MobileNo;
            applicant.PermanentAddress = model.PermanentAddress;
            applicant.Status = Status.Rejected;
            applicant.Email = model.Email;

            return applicant;
        }

        public SelectList CourseList(object selectedItem = null)
        {
            return new SelectList(_courseService.GetCourses(), "Id", "Name", selectedItem);
        }

        public void DeleteApplication(Guid id)
        {
            _applicantService.Delete(id);
        }

        public ApplicantViewModel BuildApplicantModel(Guid id)
        {
            var applicant = _applicantService.GetApplicant(id);
            return new ApplicantViewModel
            {
                FirstName = applicant.FirstName,
                MiddleName = applicant.MiddleName,
                LastName = applicant.LastName,
                Gender = applicant.Gender,
                DateOfBirth = applicant.DateOfBirth,
                Nationality = applicant.Nationality,
                MobileNo = applicant.MobileNo,
                BirthCertificateNo = applicant.BirthCertificateNo,
                NationalIdentificationNo = applicant.NationalIdentificationNo,
                EnrollCourse = CourseList(applicant.CourseId),
                ImagePath = FormatImageUrl(applicant.ImageUrl),
                Religion = applicant.Religion,
                BloodGroup = applicant.BloodGroup,
            };
        }

        public void UpdateApplicant(Guid id, ApplicantViewModel model)
        {
            var exStudent = _applicantService.GetApplicant(id);

            exStudent.FirstName = model.FirstName;
            exStudent.MiddleName = model.MiddleName;
            exStudent.LastName = model.LastName;
            exStudent.Gender = model.Gender;
            exStudent.DateOfBirth = model.DateOfBirth;
            exStudent.Nationality = model.Nationality;
            exStudent.BirthCertificateNo = model.BirthCertificateNo;
            exStudent.NationalIdentificationNo = model.NationalIdentificationNo;
            exStudent.BloodGroup = model.BloodGroup;
            exStudent.CourseId = model.CourseId;
            exStudent.PresentAddress = model.PresentAddress;
            exStudent.PermanentAddress = model.PermanentAddress;
            exStudent.Status = Status.Approved;
            exStudent.Email = model.Email;

            if (model.Photo != null)
            {
                var (fileName, filePath) = StoreFile(model.Photo);
                exStudent.ImageUrl = filePath;
                exStudent.ImageAlternativeText = fileName;
            }
            _applicantService.Update(exStudent);
        }

        public void SaveApplicant(ApplicantViewModel model)
        {
            var applicant = ConvertToEntityApplicant(model);
            applicant.RecordMeta = new RecordMeta
            {
                CreatedAt = DateTime.UtcNow
            };
            _applicantService.AddApplicant(applicant);
        }

        public IList<SubjectModel> GetSubjectModels(Guid courseId)
        {
            return _subjectService.GetSubjects(courseId).Select(x => new SubjectModel
            {
                Name = x.Name,
                Code = x.Code,
                ExcludeInResult = x.ExcludeInResult,
                Type = x.Type
            }).ToList();
        }

        public object GetApplicants(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _applicantService.GetApplicantsList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "FirstName",
                    "ImageUrl",
                    "MobileNo",
                    "Course",
                    "RecordMeta",
                    "Status",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.FirstName+" "+record.MiddleName+" "+record.LastName,
                            FormatImageUrl(record.ImageUrl),
                            record.MobileNo,
                            record.Course.Name,
                            record.RecordMeta?.CreatedAt.ToShortDateString(),
                            record.Id.ToString(),
                            record.Status.ToString()
                        }
                    ).ToArray()
            };
        }

        public void ApproveStudentApplication(ApplicationUpdateModel model)
        {
            var applicant = _applicantService.GetApplicant(model.Id);
            applicant.Status = Status.Approved;
            _applicantService.ApproveApplication(applicant);

            var student = ConvertToEntityStudent(applicant);
            student.UserId = CreateUser(applicant.Email, applicant.Email, DefaultPassword, applicant.MobileNo, RoleType.Student);
            
            _studentService.AddStudent(student);
        }

        private Guid CreateUser(string email, string username, string password, string phoneNumber, RoleType isEmployee)
        {
            var user = new ApplicationUser { UserName = username, Email = email, PhoneNumber = phoneNumber, RoleType = isEmployee };
            var result = _userManager.CreateAsync(user, password);
            return result.Result.Succeeded ? user.Id : new Guid();
        }
        private Foundation.Library.Entities.Student ConvertToEntityStudent(Applicants applicant)
        {
            return new Foundation.Library.Entities.Student
            {
                FirstName = applicant.FirstName,
                MiddleName = applicant.MiddleName,
                LastName = applicant.LastName,
                Gender = applicant.Gender,
                DateOfBirth = applicant.DateOfBirth,
                Nationality = applicant.Nationality,
                BirthCertificateNo = applicant.BirthCertificateNo,
                NationalIdentificationNo = applicant.NationalIdentificationNo,
                BloodGroup = applicant.BloodGroup,
                PresentAddress = applicant.PresentAddress,
                MobileNo = applicant.MobileNo,
                PermanentAddress = applicant.PermanentAddress,
                Status = applicant.Status == Status.Approved
            };


        }

        public void RejectStudentApplication(ApplicationUpdateModel model)
        {
            var applicant = _applicantService.GetApplicant(model.Id);
            applicant.Status = Status.Rejected;
            _applicantService.RejectApplication(applicant);
        }

        public Applicants GetRequestForApplicationDetails(Guid id)
        {
            var applicant = _applicantService.GetApplicant(id);
            applicant.ImageUrl = FormatImageUrl(applicant.ImageUrl);
            return applicant;
        }
    }
}