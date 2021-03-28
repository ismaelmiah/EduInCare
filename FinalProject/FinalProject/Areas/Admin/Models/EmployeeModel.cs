using System;
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
        private readonly IExamTitleService _examTitleService;
        private readonly IEmploymentHistoryService _employmentHistory;
        private readonly IJobInfoService _jobInfoService;
        private readonly IDesignationService _designationService;

        public EmployeeModel(
            IEmployeeService employeeService,
            IEmployeeEducationService employeeEducationService,
            IEducationLevelService educationLevelService,
            IExamTitleService examTitleService,
            IEmploymentHistoryService employmentHistory,
            IJobInfoService jobInfo,
            IDesignationService designationService)
        {
            _employeeService = employeeService;
            _employeeEducationService = employeeEducationService;
            _educationLevelService = educationLevelService;
            _examTitleService = examTitleService;
            _employmentHistory = employmentHistory;
            _jobInfoService = jobInfo;
            _designationService = designationService;
        }

        public EmployeeModel()
        {
            _designationService = Startup.AutofacContainer.Resolve<IDesignationService>(); ;
            _jobInfoService = Startup.AutofacContainer.Resolve<IJobInfoService>();
            _examTitleService = Startup.AutofacContainer.Resolve<IExamTitleService>();
            _educationLevelService = Startup.AutofacContainer.Resolve<IEducationLevelService>();
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _employeeEducationService = Startup.AutofacContainer.Resolve<IEmployeeEducationService>();
            _employmentHistory = Startup.AutofacContainer.Resolve<IEmploymentHistoryService>();
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
                    "Name",
                    "UserName",
                    "Section",
                    "Photo",
                    "Gender",
                    "PresentAddress",
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
                            record.UserName,
                            record.Section?.Name,
                            record.ImageUrl,
                            ((Gender)(record.Gender)).ToString(),
                            record.PresentAddress,
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

        public object GetExamTitles(DataTablesAjaxRequestModel tableModel)
        {

            var (total, totalDisplay, records) = _examTitleService.GetExamTitleList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "TitleName",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.TitleName,
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }

        public object GetEmploymentHistories(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _employmentHistory.GetEmploymentHistoryList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Employee",
                    "Designation",
                    "CompanyName",
                    "CompanyLocation",
                    "From",
                    "To",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.Employee.Name,
                            record.Designation,
                            record.CompanyName,
                            record.CompanyLocation,
                            record.From.ToShortDateString(),
                            record.To.ToShortDateString(),
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }

        public object GetJobInfos(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _jobInfoService.GetEmployeeList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Employee",
                    "Designation",
                    "JoiningDate",
                    "Salary",
                    "TotalLeave",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.Employee.Name,
                            record.Designation.Name,
                            record.JoiningDate.ToShortDateString(),
                            record.Salary.ToString(CultureInfo.InvariantCulture),
                            record.TotalLeave.ToString(),
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }

        public object GetDesignations(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _designationService.GetDesignationList(
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
                        select new[]
                        {
                            record.Name,
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }
    }
}