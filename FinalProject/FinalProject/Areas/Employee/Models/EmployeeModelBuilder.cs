using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Areas.Student.Models;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class EmployeeModelBuilder : BaseModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeModelBuilder(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public EmployeeModelBuilder()
        {
            _departmentService = Startup.AutofacContainer.Resolve<IDepartmentService>();
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
        }
        public EmployeeFormViewModel BuildEmployeeModel(Guid id)
        {
            var employee = _employeeService.GetEmployeeWithoutTrack(id);
            return new EmployeeFormViewModel
            {
                Name = employee.Name,
                Gender = employee.Gender,
                JoinOfDate = employee.JoinOfDate,
                Nationality = employee.Nationality,
                MobileNo = employee.MobileNo,
                UserName = employee.UserName,
            };
        }

        internal IList<SelectListItem> GetDepartmentItems()
        {
            return _departmentService.GetDepartments().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        private AddressModel BuildAddressModel(string address)
        {
            var fullAddress = address.Split(",");
            var addressModel = new AddressModel
            {
                Street = fullAddress[0],
                City = fullAddress[1],
                ZipCode = fullAddress[2]
            };
            return addressModel;
        }

        public void SaveEmployee(EmployeeFormViewModel model)
        {
            var employee = ConvertToEntity(model);
            _employeeService.AddEmployee(employee);
        }

        private Foundation.Library.Entities.Employee ConvertToEntity(EmployeeFormViewModel model)
        {
            var employee = new Foundation.Library.Entities.Employee();
            if (model.Photo != null)
            {
                var imageInfo = StoreFile(model.Photo);
            }

            employee.Name = model.Name;
            employee.FatherName = model.FatherName;
            employee.MotherName = model.MotherName;
            employee.Gender = model.Gender;
            employee.JoinOfDate = model.JoinOfDate;
            employee.MaritalStatus = model.MaritalStatus;
            employee.Religion = model.Religion;
            employee.Nationality = model.Nationality;
            employee.Nid = model.Nid;
            employee.PresentAddress = model.PresentAddress;
            employee.PermanentAddress = model.PermanentAddress;
            employee.MobileNo = model.MobileNo;
            employee.UserName = model.UserName;

            return employee;
        }

        private Department GetSelectedDepartment(Guid departmentId) => _departmentService.GetDepartment(departmentId);

        public void UpdateEmployee(Guid modelId, EmployeeFormViewModel model)
        {
            var exEmployee = _employeeService.GetEmployee(modelId);

            exEmployee.Name = model.Name;
            exEmployee.Gender = model.Gender;
            exEmployee.MobileNo = model.MobileNo;
            exEmployee.Nationality = model.Nationality;
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
    }
}