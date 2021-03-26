using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class EmploymentHistoryModel
    {
        internal EmploymentHistoryModelBuilder ModelBuilder;

        public EmploymentHistoryModel()
        {
            ModelBuilder = new EmploymentHistoryModelBuilder();
            EmployeeList = ModelBuilder.EmployeeListItems();
        }
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public string Designation { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Guid EmployeeId { get; set; }
        public IList<SelectListItem> EmployeeList { get; set; }
    }
}