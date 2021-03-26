using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class JobInfoModelBuilder
    {
        private readonly IEmployeeService _employee;
        private readonly IJobInfoService _jobInfoService;
        private readonly IDesignationService _designation;

        public JobInfoModelBuilder(IEmployeeService employee, IJobInfoService jobInfoService, IDesignationService designation)
        {
            _employee = employee;
            _jobInfoService = jobInfoService;
            _designation = designation;
        }

        public JobInfoModelBuilder()
        {
            _employee = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _jobInfoService = Startup.AutofacContainer.Resolve<IJobInfoService>();
            _designation = Startup.AutofacContainer.Resolve<IDesignationService>();
        }
        public void UpdateEmployeeEducation(Guid id, JobInfoModel model)
        {
            throw new System.NotImplementedException();
        }

        public void SaveEmployeeEducation(JobInfoModel model)
        {
            var entity = ConvertToEntity(model);
            _jobInfoService.AddEmployee(entity);
        }

        private JobInfo ConvertToEntity(JobInfoModel model)
        {
            return new JobInfo
            {
                DesignationId = model.DesignationId,
                JoiningDate = model.JoiningDate,
                Salary = model.Salary,
                TotalLeave = model.TotalLeave,
                EmployeeId = model.EmployeeId
            };
        }

        public JobInfoModel BuildEmployeeEducationModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<SelectListItem> GetDesignations()
        {
            return _designation.GetDesignations().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        public IList<SelectListItem> GetEmployees()
        {
            return _employee.GetAllEmployees().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }
    }
}