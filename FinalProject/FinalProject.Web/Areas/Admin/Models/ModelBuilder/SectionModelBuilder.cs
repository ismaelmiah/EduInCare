using System;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class SectionModelBuilder
    {
        private readonly ISectionService _sectionService;
        private protected ICourseService CourseService { get; }
        private protected IEmployeeService EmployeeService { get; }

        public SectionModelBuilder(ISectionService sectionService, ICourseService courseService, IEmployeeService employeeService)
        {
            _sectionService = sectionService;
            CourseService = courseService;
            EmployeeService = employeeService;
        }

        public SectionModelBuilder()
        {
            CourseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _sectionService = Startup.AutofacContainer.Resolve<ISectionService>();
            EmployeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
        }
        public void SaveSection(SectionModel model)
        {
            var entity = ConvertToEntity(model);
            _sectionService.AddSection(entity);
        }

        private Section ConvertToEntity(SectionModel model)
        {
            return new Section
            {
                Name = model.Name,
                Capacity = model.Capacity,
                CourseId = model.CourseId,
                TeacherId = model.TeacherId,
                Description = model.Description,
                Status = model.Status
            };
        }

        public void UpdateSection(Guid id, SectionModel model)
        {
            var exSection = _sectionService.GetSection(id);
            exSection.Name = model.Name;
            exSection.Capacity = model.Capacity;
            exSection.CourseId = model.CourseId;
            exSection.TeacherId = model.TeacherId;
            exSection.Description = model.Description;

            _sectionService.Update(exSection);
        }

        public void DeleteSection(Guid id)
        {
            _sectionService.Delete(id);
        }

        public object GetSections(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _sectionService.GetSectionList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name",
                    "Course",
                    "Employee",
                    "Capacity",
                    "Status",
                    "Description",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Name,
                            record.Course.Name,
                            record.Registration.Count(),
                            record.Employee.Name,
                            record.Capacity,
                            record.Description,
                            record.Status,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public SectionModel BuildSectionModel(Guid id)
        {
            var exSection = _sectionService.GetSection(id);

            return new SectionModel
            {
                Name = exSection.Name,
                Capacity = exSection.Capacity,
                CourseId = exSection.CourseId,
                TeacherId = exSection.TeacherId,
                Description = exSection.Description,
                Status = exSection.Status,
                TeacherList = GetTeacherList(exSection.TeacherId),
                CourseList = GetCourseList(exSection.CourseId)
            };
        }


        public SelectList GetTeacherList(object selectedTeacher = null)
        {
            var teachers = EmployeeService.GetAllEmployees();
            return new SelectList(teachers, "Id", "Name", selectedTeacher);
        }

        public SelectList GetCourseList(object selectedCourse = null)
        {
            var courses = CourseService.GetCourses();
            return new SelectList(courses, "Id", "Name", selectedCourse);
        }
    }
}