using System;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
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
            throw new NotImplementedException();
        }

        public void UpdateRegistration(Guid modelId, RegistrationModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteRegistration(Guid id)
        {
            throw new NotImplementedException();
        }

        public SelectList GetCourseList(object selectedItem = null)
        {
            return new SelectList(_course.GetCourses(), "Id", "Name", selectedItem);
        }

        public SelectList GetSectionList(object selectedItem = null)
        {
            return new SelectList(_section.GetSections(), "Id", "Name", selectedItem);
        }

        public SelectList GetAcademicYearList(object selectedItem = null)
        {
            return new SelectList(_academic.GetAcademicYears(), "Id", "Title", selectedItem);
        }

        public SelectList GetStudentList(object selectedItem = null)
        {
            var studentList = _student.GetStudents().Select(x => 
                new { Id = x.Id, Name = $"{x.FirstName} {x.MiddleName} {x.LastName}" }).ToList();

            return new SelectList(studentList, "Id", "", selectedItem);
        }
    }
}