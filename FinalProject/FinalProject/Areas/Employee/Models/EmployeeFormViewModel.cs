using System;
using System.Collections.Generic;
using FinalProject.Web.Areas.Student.Models;
using Foundation.Library.Entities;
using Foundation.Library.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class EmployeeFormViewModel
    {
        internal EmployeeModelBuilder ModelBuilder;
        public EmployeeFormViewModel()
        {
            ModelBuilder = new EmployeeModelBuilder();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NationalIdentificationNo { get; set; }
        public Gender Gender { get; set; }
        public string MobileNo { get; set; }
        public AddressModel PresentAddress { get; set; }
        public AddressModel PermanentAddress { get; set; }
        public string Nationality { get; set; }
        public DateTime JoinOfDate { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Photo { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public int EducationLevelId { get; set; }
        public List<SelectListItem> EducationLevel { get; set; }
        public int ExamTitleId { get; set; }
        public List<SelectListItem> ExamTitle { get; set; }
        public string Major { get; set; }
        public string InstituteName { get; set; }
        public ResultType ResultType { get; set; }
        public float Cgpa { get; set; }
        public int Scale { get; set; }
        public float Marks { get; set; }
        public string PassingYear { get; set; }
        public int Duration { get; set; }
        public string Achievement { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public string Designation { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int DesignationId { get; set; }
        public Designation NewDesignation { get; set; }
        public DateTime Doj { get; set; }
        public decimal Salary { get; set; }
        public int TotalLeave { get; set; }
        public IFormFile AppointmentImage { get; set; }
        public IList<SelectListItem> JobInfo { get; set; }
        public IList<SelectListItem> EmployeeEducation { get; set; }
        public IList<SelectListItem> EmploymentHistory { get; set; }
    }
}