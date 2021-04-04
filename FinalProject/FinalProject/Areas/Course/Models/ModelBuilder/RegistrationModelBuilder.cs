using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Course.Models.ModelBuilder
{
    public class RegistrationModelBuilder
    {
        private readonly IStudentService _student;
        private readonly IAcademicYearService _academic;
        private readonly ICourseService _course;
        private readonly IRegistrationStudentService _registration;
        private readonly ISectionService _section;

        public RegistrationModelBuilder(IStudentService student, IAcademicYearService academic, ICourseService course, IRegistrationStudentService registration, ISectionService section)
        {
            _student = student;
            _academic = academic;
            _course = course;
            _registration = registration;
            _section = section;
        }

        public RegistrationModelBuilder()
        {
            _course = Startup.AutofacContainer.Resolve<ICourseService>();
            _student = Startup.AutofacContainer.Resolve<IStudentService>();
            _academic = Startup.AutofacContainer.Resolve<IAcademicYearService>();
            _registration = Startup.AutofacContainer.Resolve<IRegistrationStudentService>();
            _section = Startup.AutofacContainer.Resolve<ISectionService>();
        }
        public object GetRegisteredData(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _registration.GetRegistrationList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "RegistrationNo",
                    "Student",
                    "RollNo",
                    "Section",
                    "Course",
                    "Shift",
                    "AcademicYear",
                    "Status",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.RegistrationNo,
                            record.Student.FirstName+ " "+ record.Student.MiddleName + " "+record.Student.LastName,
                            record.RollNo,
                            record.Section.Name,
                            record.Course.Name,
                            record.Shift.ToString(),
                            record.AcademicYear.Title,
                            record.Status,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public RegistrationModel BuildRegistrationModel(Guid id)
        {
            var exEntity = _registration.GetRegistration(id);
            return new RegistrationModel
            {
                CourseList = GetCourseList(exEntity.CourseId),
                AcademicYearList = GetAcademicYearList(exEntity.AcademicYearId),
                StudentList = GetStudentList(exEntity.Id),
                BoardRegistrationNo = exEntity.BoardRegistrationNo,
                IdCardNo = exEntity.CardNo,
                IsPromoted = exEntity.IsPromoted,
                Status = exEntity.Status,
                Shift = exEntity.Shift,
                SectionList = GetSectionList(exEntity.SectionId),
                RollNo = exEntity.RollNo,
            };
        }

        public void SaveRegistration(RegistrationModel model)
        {
            var entity = ConvertToEntity(model);
            _registration.AddRegistration(entity);
        }

        private static Registration ConvertToEntity(RegistrationModel model)
        {
            return new Registration
            {
                CourseId = model.CourseId,
                AcademicYearId = model.AcademicYearId,
                StudentId = model.StudentId,
                BoardRegistrationNo = model.BoardRegistrationNo,
                CardNo = model.IdCardNo,
                IsPromoted = model.IsPromoted,
                Status = model.Status,
                Shift = model.Shift,
                SectionId = model.SectionId,
                RollNo = model.RollNo,
                OldRegistrationId = model.OldRegistrationId
            };
        }

        public void UpdateRegistration(Guid id, RegistrationModel model)
        {
            var exEntity = _registration.GetRegistration(id);
            exEntity.Status = model.Status;
            exEntity.RollNo = model.RollNo;
            exEntity.Shift = model.Shift;
            exEntity.SectionId = model.SectionId;
            exEntity.CourseId = model.CourseId;
            exEntity.AcademicYearId = model.AcademicYearId;
            exEntity.StudentId = model.StudentId;
            exEntity.OldRegistrationId = model.OldRegistrationId;
            exEntity.RegistrationNo = model.BoardRegistrationNo;
            exEntity.BoardRegistrationNo = model.BoardRegistrationNo;
            exEntity.IsPromoted = model.IsPromoted;

            _registration.Update(exEntity);
        }

        public void DeleteRegistration(Guid id)
        {
            _registration.Delete(id);
        }

        public SelectList GetCourseList(Guid yearId, object selectedItem = null)
        {
            var courses = _course.GetCourses(yearId);
            return new SelectList(courses, "Id", "Name", selectedItem);
        }

        public SelectList GetSectionList(Guid courseId, object selectedItem = null)
        {
            return new SelectList(_section.GetSections(courseId), "Id", "Name", selectedItem);
        }

        public SelectList GetAcademicYearList(object selectedItem = null)
        {
            return new SelectList(_academic.GetAcademicYears(), "Id", "Title", selectedItem);
        }

        public SelectList GetStudentList(Guid courseId, Guid sectionId, int shift)
        {
            var studentList = _student.GetStudents(courseId, sectionId, shift).Select(x => 
                new { Id = x.Id, Name = $"{x.FirstName} {x.MiddleName} {x.LastName}" }).ToList();

            return new SelectList(studentList, "Id", "Name", selectedItem);
        }
    }
}