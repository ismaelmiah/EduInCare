using System;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;
using FinalProject.Web.Models;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class GroupModel
    {
        internal GroupModelBuilder ModelBuilder;

        public GroupModel()
        {
            ModelBuilder = new GroupModelBuilder();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public object GetGroups(DataTablesAjaxRequestModel tableModel)
        {
            throw new NotImplementedException();
            //var (total, totalDisplay, records) = _courseService.GetCourseList(
            //    tableModel.PageIndex,
            //    tableModel.PageSize,
            //    tableModel.SearchText,
            //    tableModel.GetSortText(new[]
            //    {
            //        "Title",
            //        "Students",
            //        "Department"
            //    }));

            //return new
            //{
            //    recordsTotal = total,
            //    recordsFiltered = totalDisplay,
            //    data = (from record in records
            //            select new object[]
            //            {
            //                record.Name,
            //                record.Department.Name,
            //                record.Id.ToString(),
            //            }
            //        ).ToArray()
            //};
        }
    }
}
