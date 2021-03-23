using System;
using System.Collections.Generic;
using Foundation.Library.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class JobInfoModel
    {
        internal JobInfoModelBuilder ModelBuilder;

        public JobInfoModel()
        {
            ModelBuilder = new JobInfoModelBuilder();
            DesignationList = ModelBuilder.GetDesignations();
            EmployeeList = ModelBuilder.GetEmployees();
        }

        public Guid Id { get; set; }
        public Guid DesignationId { get; set; }
        public IList<SelectListItem> DesignationList { get; set; }
        public DateTime JoiningDate { get; set; }
        public decimal Salary { get; set; }
        public int TotalLeave { get; set; }
        public IFormFile Appointment { get; set; }
        public Guid EmployeeId { get; set; }
        public IList<SelectListItem> EmployeeList { get; set; }
    }
}