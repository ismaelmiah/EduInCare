using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class EmploymentHistoryModelBuilder
    {
        private readonly IEmployeeService _employee;
        private readonly IEmploymentHistoryService _employmentHistory;

        public EmploymentHistoryModelBuilder(IEmployeeService employee, IEmploymentHistoryService employmentHistory)
        {
            _employee = employee;
            _employmentHistory = employmentHistory;
        }

        public EmploymentHistoryModelBuilder()
        {
            _employee = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _employmentHistory = Startup.AutofacContainer.Resolve<IEmploymentHistoryService>();
        }

        internal IList<SelectListItem> EmployeeListItems()
        {
            return _employee.GetAllEmployees().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        public void UpdateEmploymentHistoryModel(Guid modelId, EmploymentHistoryModel model)
        {
            throw new NotImplementedException();
        }

        public void SaveEmploymentHistoryModel(EmploymentHistoryModel model)
        {
            var entity = ConvertToEntity(model);
            _employmentHistory.AddEmploymentHistory(entity);
        }

        private EmploymentHistory ConvertToEntity(EmploymentHistoryModel model)
        {
            return new EmploymentHistory
            {
                CompanyLocation = model.CompanyLocation,
                CompanyName = model.CompanyName,
                Designation = model.Designation,
                EmployeeId = model.EmployeeId,
                From = model.From,
                To = model.To,
            };
        }

        public EmploymentHistoryModel BuildEmploymentHistoryModel(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}