using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class CourseModel
    {
        private readonly ICourseService _courseService;
        private readonly IDepartmentService _department;

        public CourseModel(ICourseService courseService, IDepartmentService department)
        {
            _courseService = courseService;
            _department = department;
        }

        public CourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _department = Startup.AutofacContainer.Resolve<IDepartmentService>();

            DepartmentList = _department.GetDepartments().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }
        public string Title { get; set; }
        public Guid DepartmentId { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        internal object GetClasses(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _courseService.GetCourseList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Title",
                    "Students",
                    "Department"
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Title,
                            record.Students.Count(),
                            record.Department.Name,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public void SaveCourse()
        {
            _courseService.AddCourse(new Course { Title = Title, DepartmentId = DepartmentId});
        }

        public void DeleteCourse(Guid id)
        {
            _courseService.Delete(id);
        }
    }
}