using System;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class CourseModel
    {
        public string Title { get; set; }
        private readonly ICourseService _courseService;

        public CourseModel(ICourseService courseService) { _courseService = courseService; }

        public CourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        internal object GetClasses(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _courseService.GetCourseList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Title",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.Title,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public void SaveCourse()
        {
            _courseService.AddCourse(new Course{Title = this.Title});
        }

        public void DeleteCourse(Guid id)
        {
            _courseService.Delete(id);
        }
    }
}