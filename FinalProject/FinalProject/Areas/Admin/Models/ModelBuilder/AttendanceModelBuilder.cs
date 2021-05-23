using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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


        private static StudentAttendance ConvertToEntity(List<AttendanceModel> model)
        {
            return new StudentAttendance
            {
                AttendanceInfo = JsonConvert.SerializeObject(model),
                AttendanceDate = DateTime.UtcNow
            };
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

        public object GetStudentList(DataTablesAjaxRequestModel tableModel, Guid courseId, Guid sectionId )
        {
            var students = _registration.GetRegistrations()
                .Where(x => x.CourseId == courseId && x.SectionId == sectionId);

            var attendance = students.Select(x => new AttendanceModel
            {
                CourseId = x.CourseId,
                IsPresent = false,
                SectionId = x.SectionId,
                StudentId = x.StudentId
            }).ToList();

            var todayAttendance = _attendance.GetList();
            if (todayAttendance.Any())
            {
                todayAttendance = todayAttendance.Where(x => x.AttendanceDate == DateTime.UtcNow).ToList();

                bool alreadyDone = todayAttendance.Select(to => JsonConvert.DeserializeObject<List<AttendanceModel>>(to.AttendanceInfo))
                    .Any(data => data.Any(x => x.CourseId == courseId && x.SectionId == sectionId));

                if (!alreadyDone && todayAttendance.Count() != 0)
                {
                    var entity = ConvertToEntity(attendance);
                    _attendance.Create(entity);
                }
            }

            var (total, totalDisplay, records) = _attendance.GetListForDataTable(tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "AttendanceInfo",
                    "AttendanceDate",
                }));

            var today = records.FirstOrDefault(x => x.AttendanceDate.ToShortDateString() == DateTime.UtcNow.ToShortDateString());
            var studentAttendanceModels = JsonConvert.DeserializeObject<List<AttendanceModel>>(today.AttendanceInfo);


            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in studentAttendanceModels
                        select new object[]
                        {
                            record.StudentName,
                            record.RollNo,
                            record.IsPresent,
                            record.StudentId.ToString(),
                        }
                    ).ToArray()

            };
        }
    }

    public class AttendanceModel
    {
        public string StudentName { get; set; }
        public int RollNo { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Guid SectionId { get; set; }
        public bool IsPresent { get; set; }
    }
}