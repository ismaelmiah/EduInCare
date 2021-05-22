using System;
using System.Linq;
using Autofac;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class AttendanceModelBuilder
    {
        private readonly IStudentService _student;
        private readonly IAcademicYearService _academic;
        private readonly ICourseService _course;
        private readonly IRegistrationStudentService _registration;
        private readonly ISectionService _section;
        private readonly IStudentAttendanceService _attendance;

        public AttendanceModelBuilder(
            IStudentService student,
            IAcademicYearService academic,
            ICourseService course,
            IRegistrationStudentService registration,
            ISectionService section,
            IStudentAttendanceService attendance)
        {
            _student = student;
            _academic = academic;
            _course = course;
            _registration = registration;
            _section = section;
            _attendance = attendance;
        }

        public AttendanceModelBuilder()
        {
            _course = Startup.AutofacContainer.Resolve<ICourseService>();
            _student = Startup.AutofacContainer.Resolve<IStudentService>();
            _academic = Startup.AutofacContainer.Resolve<IAcademicYearService>();
            _registration = Startup.AutofacContainer.Resolve<IRegistrationStudentService>();
            _section = Startup.AutofacContainer.Resolve<ISectionService>();
            _attendance = Startup.AutofacContainer.Resolve<IStudentAttendanceService>();
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
                            record.AcademicYear.Title,
                            record.Status,
                            record.Id.ToString(),
                        }
                    ).ToArray()
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
                SectionId = model.SectionId,
                RollNo = model.RollNo,
                OldRegistrationId = model.OldRegistrationId,
                RegistrationNo = model.RegistrationNo
            };
        }

        public void UpdateRegistration(Guid id, RegistrationModel model)
        {
            var exEntity = _registration.GetRegistration(id);
            exEntity.Status = model.Status;
            exEntity.RollNo = model.RollNo;
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

        public SelectList GetCourseList()
        {
            var courses = _course.GetCourses();
            return new SelectList(courses, "Id", "Name", null);
        }

        public SelectList GetSectionList(Guid courseId, object selectedItem = null)
        {
            return new SelectList(_section.GetSections(courseId), "Id", "Name", selectedItem);
        }

        public object GetStudentList(DataTablesAjaxRequestModel tableModel, Guid courseId)
        {
            var (total, totalDisplay, records) = _attendance.GetListForDataTable(courseId,
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Student",
                    "IsPresent",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            $"{record.Student.FirstName} {record.Student.MiddleName} {record.Student.LastName}",
                            record.Student.RollNo,
                            record.IsPresent,
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }
    }
}