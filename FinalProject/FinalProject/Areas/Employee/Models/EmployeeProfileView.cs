using System;
using System.Collections.Generic;
using FinalProject.Web.Areas.Employee.Models.ModelBuilder;
using Foundation.Library.Enums;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class EmployeeProfileView
    {
        internal EmployeeModelBuilder ModelBuilder;
        public EmployeeProfileView()
        {
            ModelBuilder = new EmployeeModelBuilder();
        }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalIdentificationNo { get; set; }
        public Gender Gender { get; set; }
        public Religion Religion { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime JoinDate { get; set; }
        public string ImagePath { get; set; }
        public string AlterImageName { get; set; }
        public string Designation { get; set; }
        public WorkShift WorkShift { get; set; }
        public IList<string> Qualifications { get; set; }
        public bool Status { get; set; }
        public string IdCardNo { get; set; }
        public bool isAdmin { get; set; }
    }
}