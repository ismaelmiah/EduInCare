using System;
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
        private readonly IAcademicYearService _academicYear;

        public CourseModelBuilder(ICourseService courseService, IDepartmentService department, IAcademicYearService academicYear)
        {
            _courseService = courseService;
            _department = department;
            _academicYear = academicYear;
        }

        public CourseModelBuilder()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _department = Startup.AutofacContainer.Resolve<IDepartmentService>();
            _academicYear = Startup.AutofacContainer.Resolve<IAcademicYearService>();
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
                MaxCompulsorySubject = model.MaxCompulsorySubject,
                AcademicYearId = model.AcademicYearId
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
                Status = exCourse.Status,
                AcademicYearId = exCourse.AcademicYearId,
                AcademicYearList = PopulateAcademicYearDropDownList(exCourse.AcademicYearId)
            };
        }

        public void UpdateCourse(Guid id, CourseModel model)
        {
            var exCourse = _courseService.GetCourse(id);
            exCourse.Name = model.Title;
            exCourse.DepartmentId = model.DepartmentId;
            exCourse.Description = model.Description;
            exCourse.Status = model.Status;
            exCourse.Duration = model.Duration;
            exCourse.MaxCompulsorySubject = model.MaxCompulsorySubject;
            exCourse.AcademicYearId = model.AcademicYearId;
            exCourse.HaveCompulsorySubject = model.HaveCompulsorySubject;
            _courseService.Update(exCourse);
        }

        internal SelectList PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentList = from d in _department.GetDepartments() select d;

            return new SelectList(departmentList, "Id","Name", selectedDepartment);
        }

        public SelectList PopulateAcademicYearDropDownList(object selectedYear = null)
        {
            var academicYears = from d in _academicYear.GetAcademicYears() select d;

            return new SelectList(academicYears, "Id", "Title", selectedYear);
        }
    }
}