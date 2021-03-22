using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class EmployeeModel : BaseModel
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public EmployeeModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
        }
        public object GetEmployees(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _employeeService.GetEmployeeList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "FirstName",
                    "MiddleName",
                    "LastName",
                    "Photo",
                    "Gender",
                    "Department",
                    "JoiningDate",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.Name,
                            record.JoinOfDate.ToShortDateString(),
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }

        public object GetTeachers(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _employeeService.GetEmployeeList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "FirstName",
                    "MiddleName",
                    "LastName",
                    "Photo",
                    "Gender",
                    "Department",
                    "JoiningDate",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.Name,
                            record.JoinOfDate.ToShortDateString(),
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }
    }
}