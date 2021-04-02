﻿using System;
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
            DesignationList = ModelBuilder.GetDesignationList();
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
        public DateTime JoinOfDate { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Photo { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public RoleType Role { get; set; }
        public ResultType ResultType { get; set; }
        public Guid DesignationId { get; set; }
        public SelectList DesignationList { get; set; }
    }
}