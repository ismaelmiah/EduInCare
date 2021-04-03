using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FinalProject.Web.Areas.Employee.Models.ModelBuilder;
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
            QualificationType = (List<SelectListItem>)ModelBuilder.GetQualificationTypes();
            DesignationList = ModelBuilder.GetDesignationList();
            QualificationType = (List<SelectListItem>)ModelBuilder.GetQualificationTypes();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "National Identification Number")]
        public string Nid { get; set; }
        public Gender Gender { get; set; }
        public string MobileNo { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Religion Religion { get; set; }
        public DateTime JoinOfDate { get; set; }
        public string IdCardNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Photo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{6,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }
        public IList<int> Qualifications { get; set; }
        public List<SelectListItem> QualificationType { get; set; }
        public Guid DesignationId { get; set; }
        public SelectList DesignationList { get; set; }
        public RoleType Role { get; set; }
        public ResultType ResultType { get; set; }
        public WorkShift Shift { get; set; }
    }
}