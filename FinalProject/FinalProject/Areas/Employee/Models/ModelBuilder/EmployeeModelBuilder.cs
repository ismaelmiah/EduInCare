using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Enums;
using Foundation.Library.Services;
using Membership.Library.Constants;
using Membership.Library.Contexts;
using Membership.Library.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Employee.Models.ModelBuilder
{
    public class EmployeeModelBuilder : BaseModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IDesignationService _designationService;
        private readonly IDepartmentService _department;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmployeeService _employeeService;

        public EmployeeModelBuilder(
            ApplicationDbContext db,
            IEmployeeService employeeService,
            IDesignationService designationService,
            IDepartmentService department,
            UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _employeeService = employeeService;
            _designationService = designationService;
            _department = department;
            _userManager = userManager;
        }

        internal string GetNewEmployeeIdCardNo()
        {
            return "emp_"+ _employeeService.GetAllEmployees().Count();
        }

        public EmployeeModelBuilder()
        {
            _db = Startup.AutofacContainer.Resolve<ApplicationDbContext>();
            _userManager = Startup.AutofacContainer.Resolve<UserManager<ApplicationUser>>();
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
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
            var (_, totalDisplay, records) = _employeeService.GetEmployeeList(
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
        
        internal List<SelectListItem> GetRolesItems()
        {
            return Enum.GetValues(typeof(RoleType)).Cast<RoleType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
        }
        
        public async Task SaveEmployee(EmployeeFormViewModel model)
        {
            var userId = await CreateUser(model.Email, model.UserName, model.Password, model.MobileNo, model.Role);
            var employee =  ConvertToEntity(model);
            employee.UserId = userId;
            _employeeService.AddEmployee(employee);
        }
        private async Task<Guid> CreateUser(string email, string username, string password, string phoneNumber, RoleType isEmployee)
        {
            var user = new ApplicationUser { UserName = username, Email = email, PhoneNumber = phoneNumber, RoleType = isEmployee };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddClaimsAsync(
                    user,
                    new List<Claim>
                    {
                            new Claim(MembershipClaims.MemberClaimType, MembershipClaims.MemberClaimValue)
                    });

                return user.Id;
            }
            return new Guid();
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
                MobileNo = model.MobileNo,
                PresentAddress = model.PresentAddress,
                PermanentAddress = model.PermanentAddress,
                WorkShift = model.Shift,
                Qualifications = string.Join(",", model.Qualifications.Select(i => (QualificationType)i).ToList()
                    .Select(s => Enum.GetName(typeof(QualificationType), s))),
                Status = false,
                DesignationId = model.DesignationId
            };
        }

        public void UpdateEmployee(Guid modelId, EmployeeFormViewModel model)
        {
            var exEmployee = _employeeService.GetEmployee(modelId);

            exEmployee.Name = model.Name;
            exEmployee.Gender = model.Gender;
            exEmployee.MobileNo = model.MobileNo;
            if (model.Photo != null)
            {
                var (fileName, filePath) = StoreFile(model.Photo);
                exEmployee.ImageUrl = filePath;
                exEmployee.ImageAlternativeText = fileName;
            }
            _employeeService.UpdateEmployee(exEmployee);
        }
        
        public void DeleteEmployee(Guid id)
        {
            _employeeService.DeleteEmployee(id);
        }

        public SelectList GetDesignationList(object selected = null)
        {
            return new SelectList(_designationService.GetDesignations().Where(x => !x.Name.Equals("Assistant Principle")
                && !x.Name.Equals("Principle")).OrderBy(x=>x.Name), "Id", "Name", selected);
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

        public EmployeeProfileView BuildEmployeeProfile(Guid id)
        {

            var employee = _employeeService.GetEmployee(id);

            return new EmployeeProfileView()
            {
                Name = employee.Name,
                Gender = employee.Gender,
                DateOfBirth = employee.BirthDate,
                MobileNo = employee.MobileNo,
                JoinDate = employee.JoinOfDate,
                NationalIdentificationNo = employee.Nid,
                ImagePath = FormatImageUrl(employee.ImageUrl),
                Religion = employee.Religion,
                Email = employee.Email,
                UserName = employee.UserName,
                PresentAddress = employee.PresentAddress,
                PermanentAddress = employee.PermanentAddress,
                WorkShift = employee.WorkShift??WorkShift.Day,
                Status = employee.Status,
                Qualifications = employee.Qualifications.Split(',').ToList(),
                Designation = employee.Designation.Name,
                IdCardNo = employee.CardId,
                AlterImageName = employee.ImageAlternativeText
            };
        }
    }
}