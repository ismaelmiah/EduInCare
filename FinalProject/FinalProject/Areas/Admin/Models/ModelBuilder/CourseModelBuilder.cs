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
        private readonly IGroupService _groupService;

        public CourseModelBuilder(ICourseService courseService, IDepartmentService department, IGroupService groupService)
        {
            _courseService = courseService;
            _department = department;
            _groupService = groupService;
        }

        public CourseModelBuilder()
        {
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _department = Startup.AutofacContainer.Resolve<IDepartmentService>();
        }

        internal List<SelectListItem> GetDepartmentList() => _department.GetDepartments().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

        internal object GetClasses(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _courseService.GetCourseList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name",
                    "Group",
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
                            record.Group.Name,
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
                GroupId = model.GroupId,
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

        public List<SelectListItem> GetGroupList() => _groupService.GetGroups().Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString()
        }).ToList();

        public CourseModel BuildCourseModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(Guid modelId, CourseModel model)
        {
            throw new NotImplementedException();
        }
    }
}