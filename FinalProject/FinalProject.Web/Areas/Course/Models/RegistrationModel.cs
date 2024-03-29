﻿using System;
using System.ComponentModel.DataAnnotations;
using FinalProject.Web.Areas.Course.Models.ModelBuilder;
using Foundation.Library.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Course.Models
{
    public class RegistrationModel
    {
        internal RegistrationModelBuilder ModelBuilder;
        public RegistrationModel()
        {
            ModelBuilder = new RegistrationModelBuilder();
        }

        public Guid Id { get; set; }
        public string RegistrationNo { get; set; }
        [Display(Name = "Student")]
        public Guid StudentId { get; set; }
        public SelectList StudentList { get; set; }
        [Display(Name = "Course")]
        public Guid CourseId { get; set; }
        public SelectList CourseList { get; set; }
        [Display(Name = "Section")]
        public Guid SectionId { get; set; }
        public SelectList SectionList { get; set; }
        [Display(Name = "Academic Year")]
        public Guid AcademicYearId { get; set; }
        public SelectList AcademicYearList { get; set; }
        public int RollNo { get; set; }
        public string IdCardNo { get; set; }
        [Display(Name = "Board Registration")]
        public string BoardRegistrationNo { get; set; }
        [Display(Name = "Is Promoted")]
        public bool IsPromoted { get; set; }
        [Display(Name = "Old Registration")]
        public string OldRegistrationId { get; set; }
        public bool Status { get; set; }
    }
}