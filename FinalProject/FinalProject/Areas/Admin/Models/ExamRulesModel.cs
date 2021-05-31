using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;
using Foundation.Library.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class ExamRulesModel
    {
        internal ExamRulesModelBuilder ModelBuilder;
        public ExamRulesModel()
        {
            ModelBuilder = new ExamRulesModelBuilder();
            GenerateList();
        }

        public Guid Id { get; set; }
        [Display(Name = "Subject")]
        public Guid SubjectId { get; set; }
        public SelectList SubjectList { get; set; }
        [Display(Name = "Class")]
        public Guid CourseId { get; set; }
        public SelectList CourseList { get; set; }
        [Display(Name = "Grade")]
        public Guid GradeId { get; set; }
        public SelectList GradeList { get; set; }
        [Display(Name = "Exam")]
        public Guid ExamId { get; set; }
        public SelectList ExamList { get; set; }
        [Display(Name = "Total Exam Marks")]
        public double TotalExamMarks { get; set; }
        [Display(Name = "Pass Marks")]
        public double PassMarks { get; set; }
        public List<DistributionModel> DistributionModels { get; set; }
        private void GenerateList()
        {
            CourseList = ModelBuilder.GetCourseList();
            GradeList = ModelBuilder.GetGradeList();
            //SubjectList = ModelBuilder.GetSubjectList();
            //ExamList = ModelBuilder.GetExamList();
        }
    }

    public class DistributionModel
    {
        public string DistributionType { get; set; }
        public int TotalMarks { get; set; }
        public int PassMarks { get; set; }
    }
}