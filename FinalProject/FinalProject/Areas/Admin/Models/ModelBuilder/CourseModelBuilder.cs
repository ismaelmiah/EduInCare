using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class CourseModelBuilder
    {
        private readonly ICourseService _courseService;
        private readonly IDepartmentService _department;

        public CourseModelBuilder(ICourseService courseService, IDepartmentService department)
        {
            _courseService = courseService;
            _department = department;
        }

        public CourseModelBuilder()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _department = Startup.AutofacContainer.Resolve<IDepartmentService>();
        }

        internal object GetClasses(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _courseService.GetCourseList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name",
                    "Subjects",
                    "Department",
                    "Duration",
                    "Status",
                    "HaveCompulsorySubject",
                    "MaxCompulsorySubject",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Name,
                            record.Subjects.Count(),
                            record.Department.Name,
                            record.Duration,
                            record.Status,
                            record.HaveCompulsorySubject,
                            record.MaxCompulsorySubject,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public void SaveCourse(CourseModel model)
        {
            var newCourse = ConvertToEntity(model);
            _courseService.AddCourse(newCourse);
        }

        private static Foundation.Library.Entities.Course ConvertToEntity(CourseModel model)
        {
            return new Foundation.Library.Entities.Course()
            {
                Name = model.Title,
                DepartmentId = model.DepartmentId,
                Duration = model.Duration,
                Status = model.Status,
                Description = model.Description,
                HaveCompulsorySubject = model.HaveCompulsorySubject,
                MaxCompulsorySubject = model.MaxCompulsorySubject
            };
        }

        public void DeleteCourse(Guid id)
        {
            _courseService.Delete(id);
        }

        public CourseModel BuildCourseModel(Guid id)
        {
            var exCourse = _courseService.GetCourse(id);
            return new CourseModel
            {
                Title = exCourse.Name,
                DepartmentList = PopulateDepartmentsDropDownList(exCourse.DepartmentId),
                DepartmentId = exCourse.DepartmentId,
                Duration = exCourse.Duration,
                Description = exCourse.Description,
                HaveCompulsorySubject = exCourse.HaveCompulsorySubject,
                Id = exCourse.Id,
                MaxCompulsorySubject = exCourse.MaxCompulsorySubject,
                Status = exCourse.Status
            };
        }

        public void UpdateCourse(Guid modelId, CourseModel model)
        {
            throw new NotImplementedException();
        }

        internal SelectList PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentList = from d in _department.GetDepartments() select d;

            return new SelectList(departmentList, "Id","Name", selectedDepartment);
        }
    }
}