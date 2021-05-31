using System;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class DepartmentModel
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentModel(IDepartmentService departmentService) { _departmentService = departmentService; }
        public DepartmentModel()
        {
            _departmentService = Startup.AutofacContainer.Resolve<IDepartmentService>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        internal object GetDepartments(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _departmentService.GetDepartmentList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Name,
                            record.Courses.Count(),
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        internal void Update(Guid id, DepartmentModel model)
        {
            var department = _departmentService.GetDepartment(id);
            department.Name = model.Name;
            _departmentService.UpdateDepartment(department);
        }

        internal DepartmentModel BuildModel(Guid id)
        {
            var department = _departmentService.GetDepartment(id);
            return new DepartmentModel
            {
                Name = department.Name,
                Id = department.Id
            };
        }

        public void SaveDepartment()
        {
            _departmentService.AddDepartment(new Department { Name = Name });
        }

        public void DeleteDepartment(Guid id)
        {
            _departmentService.DeleteDepartment(id);
        }
    }
}