using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FinalProject.Web.Areas.Employee.Models.ModelBuilder;
using Foundation.Library.Entities;
using Foundation.Library.Enums;
using Membership.Library.Entities;
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
            EducationLevel = ModelBuilder.GetEducationLevel();
            ExamTitle = ModelBuilder.GetExamTitleList();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        [Display(Name = "National Identification Number")]
        public string Nid { get; set; }
        public Gender Gender { get; set; }
        public string MobileNo { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Religion Religion { get; set; }
        public string Nationality { get; set; }
        public DateTime JoinOfDate { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Photo { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public RoleType Role { get; set; }
        public Guid EducationLevelId { get; set; }
        public List<SelectListItem> EducationLevel { get; set; }
        public Guid ExamTitleId { get; set; }
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
        public Guid DesignationId { get; set; }
        public Designation NewDesignation { get; set; }
        public DateTime Doj { get; set; }
        public decimal Salary { get; set; }
        public int TotalLeave { get; set; }
        public IFormFile AppointmentLetter { get; set; }
        public IList<SelectListItem> JobInfo { get; set; }
        public IList<SelectListItem> EmployeeEducation { get; set; }
        public IList<SelectListItem> EmploymentHistory { get; set; }
    }
}