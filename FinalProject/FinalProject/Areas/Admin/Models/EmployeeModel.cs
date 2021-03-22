using System.Globalization;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Enums;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class EmployeeModel : BaseModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeEducationService _employeeEducationService;
        private readonly IEducationLevelService _educationLevelService;

        public EmployeeModel(IEmployeeService employeeService, IEmployeeEducationService employeeEducationService, IEducationLevelService educationLevelService)
        {
            _employeeService = employeeService;
            _employeeEducationService = employeeEducationService;
            _educationLevelService = educationLevelService;
        }

        public EmployeeModel()
        {
            _educationLevelService = Startup.AutofacContainer.Resolve<IEducationLevelService>(); ;
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _employeeEducationService = Startup.AutofacContainer.Resolve<IEmployeeEducationService>();
        }
        public object GetEmployees(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _employeeService.GetEmployeeList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name",
                    "Gender",
                    "MobileNo",
                    "Photo",
                    "JoinOfDate",
                    "UserName",
                    "Nationality",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.Name,
                            record.Gender.ToString(),
                            record.MobileNo,
                            FormatImageUrl(record?.ImageUrl),
                            record.JoinOfDate.ToShortDateString(),
                            record.UserName,
                            record.Nationality,
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

        public object GetEmployeeEducations(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _employeeEducationService.GetEmployeeEducationList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Major",
                    "Major",
                    "Major",
                    "InstituteName",
                    "Cgpa",
                    "PassingYear",
                    "Duration",
                    "Employee",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.Major,
                            record.Major,
                            record.Major,
                            record.InstituteName,
                            record.Cgpa.ToString(CultureInfo.InvariantCulture),
                            record.PassingYear,
                            record.Duration.ToString(),
                            record.Employee.Name,
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }

        public object GetEducationLevels(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _educationLevelService.GetEducationLevelList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "EducationLevelName",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.EducationLevelName,
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }
    }
}