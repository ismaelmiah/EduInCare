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
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                JoinOfDate = employee.JoinOfDate,
                Nationality = employee.Nationality,
                MobileNo = employee.MobileNo,
                NationalIdentificationNo = employee.NationalIdentificationNo,
                ImagePath = FormatImageUrl(employee.Image?.Url),
                PresentAddress = BuildAddressModel(employee.Address.PresentAddress),
                PermanentAddress = BuildAddressModel(employee.Address.PermanentAddress),
                DepartmentId = employee.DepartmentId,
                EmployeeType = employee.EmployeeType
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
                employee.Image = new EmployeeImage
                {
                    Url = imageInfo.filePath,
                    AlternativeText = $"{model.FirstName} Image"
                };
            }

            employee.FirstName = model.FirstName;
            employee.MiddleName = model.MiddleName;
            employee.LastName = model.LastName;
            employee.Gender = model.Gender;
            employee.JoinOfDate = model.JoinOfDate;
            employee.Nationality = model.Nationality;
            employee.NationalIdentificationNo = model.NationalIdentificationNo;
            employee.Department = GetSelectedDepartment(model.DepartmentId);
            employee.Address = GetActualAddress(model);
            employee.EmployeeType = model.EmployeeType;

            return employee;
        }

        private EmployeeAddress GetActualAddress(EmployeeFormViewModel model) => new EmployeeAddress
        {
            PresentAddress = model.PresentAddress.Street
                             + "," + model.PresentAddress.City
                             + "," + model.PresentAddress.ZipCode,

            PermanentAddress = model.PermanentAddress.Street
                               + "," + model.PermanentAddress.City
                               + "," + model.PermanentAddress.ZipCode,
        };
        private Department GetSelectedDepartment(Guid departmentId) => _departmentService.GetDepartment(departmentId);

        public void UpdateEmployee(Guid modelId, EmployeeFormViewModel model)
        {
            var exEmployee = _employeeService.GetEmployee(modelId);

            exEmployee.FirstName = model.FirstName;
            exEmployee.MiddleName = model.MiddleName;
            exEmployee.LastName = model.LastName;
            exEmployee.Gender = model.Gender;
            exEmployee.MobileNo = model.MobileNo;
            exEmployee.Address = GetAddressChanges(model);
            exEmployee.Nationality = model.Nationality;
            if (model.Photo != null)
            {
                var imageInfo = StoreFile(model.Photo);

                exEmployee.Image = new EmployeeImage
                {
                    Url = imageInfo.filePath,
                    AlternativeText = $"{exEmployee.FirstName} Image"
                };
            }
            _employeeService.UpdateEmployee(exEmployee);
        }

        private EmployeeAddress GetAddressChanges(EmployeeFormViewModel model)
        {
            return new EmployeeAddress
            {
                PresentAddress = model.PresentAddress.Street
                + "," + model.PresentAddress.City
                + "," + model.PresentAddress.ZipCode,

                PermanentAddress = model.PermanentAddress.Street
                                   + "," + model.PermanentAddress.City
                                   + "," + model.PermanentAddress.ZipCode
            };
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