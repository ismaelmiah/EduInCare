using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Enums;
using Foundation.Library.Services;
using Membership.Library.Contexts;
using Membership.Library.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;

namespace FinalProject.Web.Areas.Employee.Models.ModelBuilder
{
    public partial class EmployeeModelBuilder : BaseModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IEmployeeEducationService _employeeEducationService;
        private readonly IEmploymentHistoryService _employmentHistory;
        private readonly IJobInfoService _jobInfoService;
        private readonly IExamTitleService _examTitleService;
        private readonly IDesignationService _designationService;
        private readonly IDepartmentService _department;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmployeeService _employeeService;
        private readonly IEducationLevelService _educationLevelService;

        public EmployeeModelBuilder(
            ApplicationDbContext db,
            IEmployeeService employeeService,
            IEmployeeEducationService employeeEducationService,
            IEducationLevelService educationLevelService,
            IExamTitleService examTitleService,
            IEmploymentHistoryService employmentHistory,
            IJobInfoService jobInfo,
            IDesignationService designationService,
            IDepartmentService department,
            UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _employeeService = employeeService;
            _employeeEducationService = employeeEducationService;
            _educationLevelService = educationLevelService;
            _examTitleService = examTitleService;
            _employmentHistory = employmentHistory;
            _jobInfoService = jobInfo;
            _designationService = designationService;
            _department = department;
            _userManager = userManager;
        }

        public EmployeeModelBuilder()
        {
            _db = Startup.AutofacContainer.Resolve<ApplicationDbContext>();
            _userManager = Startup.AutofacContainer.Resolve<UserManager<ApplicationUser>>();
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _employeeEducationService = Startup.AutofacContainer.Resolve<IEmployeeEducationService>();
            _educationLevelService = Startup.AutofacContainer.Resolve<IEducationLevelService>();
            _examTitleService = Startup.AutofacContainer.Resolve<IExamTitleService>();
            _employmentHistory = Startup.AutofacContainer.Resolve<IEmploymentHistoryService>();
            _jobInfoService = Startup.AutofacContainer.Resolve<IJobInfoService>();
            _designationService = Startup.AutofacContainer.Resolve<IDesignationService>();
            _department = Startup.AutofacContainer.Resolve<IDepartmentService>();
        }

        /// <summary>
        /// Get Employees
        /// </summary>
        /// <param name="tableModel"></param>
        /// <returns></returns>
        public object GetEmployees(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _employeeService.GetEmployeeList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name",
                    "UserName",
                    "Photo",
                    "Gender",
                    "MobileNo",
                    "JoinOfDate",
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
                            FormatImageUrl(record.ImageUrl),
                            record.Gender.ToString(),
                            record.MobileNo,
                            record.JoinOfDate.ToShortDateString(),
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }

        /// <summary>
        /// Get Teachers
        /// </summary>
        /// <param name="tableModel"></param>
        /// <returns></returns>
        public object GetTeachers(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _employeeService.GetEmployeeList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name",
                    "MobileNo",
                    "Photo",
                    "Gender",
                    "Section",
                    "JoiningDate",
                }));

            var users = _db.Users.Where(x => x.RoleType == RoleType.Teacher).ToList();
            var teachers = (from user in users from employee in records where user.Id == employee.UserId select employee).ToList();

            return new
            {
                recordsTotal = teachers.Count(),
                recordsFiltered = totalDisplay,
                data = (from record in teachers
                        select new[]
                        {
                            record.Name,
                            record.MobileNo,
                            record.ImageUrl,
                            record.Gender.ToString(),
                            record.Section?.Name,
                            record.JoinOfDate.ToShortDateString(),
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }

        /// <summary>
        /// Get Employee Educations
        /// </summary>
        /// <param name="tableModel"></param>
        /// <returns></returns>
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
                            //record.Employee.Name,
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }

        /// <summary>
        /// Get Employee Education Levels
        /// </summary>
        /// <param name="tableModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get Employee Exam Titles
        /// </summary>
        /// <param name="tableModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get Employment Histories
        /// </summary>
        /// <param name="tableModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get Employee Job Infos
        /// </summary>
        /// <param name="tableModel"></param>
        /// <returns></returns>
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
                            //record.Employee.Name,
                            //record.Designation.Name,
                            record.JoiningDate.ToShortDateString(),
                            record.Salary.ToString(CultureInfo.InvariantCulture),
                            record.TotalLeave.ToString(),
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }

        /// <summary>
        /// Get Designations
        /// </summary>
        /// <param name="tableModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Build Employee Registration Form Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeFormViewModel BuildEmployeeModel(Guid id)
        {
            var employee = _employeeService.GetEmployeeWithoutTrack(id);
            return new EmployeeFormViewModel
            {
                Name = employee.Name,
                Gender = employee.Gender,
                JoinOfDate = employee.JoinOfDate,
                MobileNo = employee.MobileNo,
                UserName = employee.UserName,
            };
        }

        /// <summary>
        /// Get DepartmentItems
        /// </summary>
        /// <returns></returns>
        internal IList<SelectListItem> GetDepartmentItems()
        {
            return _department.GetDepartments().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        internal List<SelectListItem> GetExamTitleList()
        {
            return _examTitleService.ExamTitles().Select(x => new SelectListItem
            {
                Text = x.TitleName,
                Value = x.Id.ToString()
            }).ToList();
        }

        internal List<SelectListItem> GetEducationLevel()
        {
            return _educationLevelService.GetEducationLevels().Select(x => new SelectListItem
            {
                Text = x.EducationLevelName,
                Value = x.Id.ToString()
            }).ToList();
        }

        internal List<SelectListItem> GetRolesItems()
        {
            return Enum.GetValues(typeof(RoleType)).Cast<RoleType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
        }

        internal List<SelectListItem> GetEducationItems()
        {
            return _employeeEducationService.GetEducations().Select(x => new SelectListItem
            {
                Text = x.PassingYear,
                Value = x.Id.ToString()
            }).ToList();
        }

        public void SaveEmployee(EmployeeFormViewModel model)
        {
            var userId = CreateUser(model.Email, model.UserName, model.Password, model.MobileNo, model.Role);
            var employee = ConvertToEntity(model);
            employee.UserId = userId;
            _employeeService.AddEmployee(employee);
        }
        private Guid CreateUser(string email, string username, string password, string phoneNumber, RoleType isEmployee)
        {
            var user = new ApplicationUser { UserName = username, Email = email, PhoneNumber = phoneNumber, RoleType = isEmployee };
            var result = _userManager.CreateAsync(user, password);
            return result.Result.Succeeded ? user.Id : new Guid();
        }
        /// <summary>
        /// Convert Employee From View to Entity Employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Foundation.Library.Entities.Employee ConvertToEntity(EmployeeFormViewModel model)
        {
            var (fileName, filePath) = StoreFile(model.Photo);

            return new Foundation.Library.Entities.Employee
            {
                Name = model.Name,
                BirthDate = model.DateOfBirth,
                CardId = model.IdCardNo,
                Email = model.Email,
                UserName = model.UserName,
                Gender = model.Gender,
                ImageUrl = filePath,
                ImageAlternativeText = fileName,
                Nid = model.Nid,
                JoinOfDate = model.JoinOfDate,
                PresentAddress = model.PresentAddress,
                PermanentAddress = model.PermanentAddress,
                WorkShift = model.Shift,
                Qualifications = string.Join(",", model.Qualifications.Select(i => (QualificationType)i).ToList()
                    .Select(s => Enum.GetName(typeof(QualificationType), s))),
                Status = false,
                DesignationId = model.DesignationId
            };
        }

        private Department GetSelectedDepartment(Guid departmentId) => _department.GetDepartment(departmentId);

        public void UpdateEmployee(Guid modelId, EmployeeFormViewModel model)
        {
            var exEmployee = _employeeService.GetEmployee(modelId);

            exEmployee.Name = model.Name;
            exEmployee.Gender = model.Gender;
            exEmployee.MobileNo = model.MobileNo;
            if (model.Photo != null)
            {
                var imageInfo = StoreFile(model.Photo);
                
            }
            _employeeService.UpdateEmployee(exEmployee);
        }


        public IList<SelectListItem> GetTypeList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Admin",
                    Value = "admin"
                },
                new SelectListItem
                {
                    Text = "Teacher",
                    Value = "teacher"
                },
                new SelectListItem
                {
                    Text = "Employee",
                    Value = "employee"
                },
            };
        }

        public void DeleteEmployee(Guid id)
        {
            _employeeService.DeleteEmployee(id);
        }

        public SelectList GetDesignationList(object selected = null)
        {
            return new SelectList(_designationService.GetDesignations().OrderBy(x=>x.Name), "Id", "Name", selected);
        }

        public IList<SelectListItem> GetQualificationTypes()
        {
            return Enum.GetValues(typeof(QualificationType))
                .Cast<QualificationType>().Select(x=> new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString()
                }).ToList();
        }

        public IList<SelectListItem> GetQualificationTypes()
        {
            return Enum.GetValues(typeof(QualificationType))
                .Cast<QualificationType>().Select(x=> new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString()
                }).ToList();
        }
    }
}