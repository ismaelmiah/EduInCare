using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class MarksModel
    {
        internal MarksModelBuilder ModelBuilder;

        public MarksModel()
        {
            ModelBuilder = new MarksModelBuilder();
            PopulateDropdownList();
        }

        public Guid Id { get; set; }
        [Display(Name = "Academic Year")]
        public Guid AcademicYearId { get; set; }
        public SelectList AcademicYearList { get; set; }
        [Display(Name = "Course")]
        public Guid CourseId { get; set; }
        public List<SelectListItem> CourseList { get; set; }
        [Display(Name = "Section")]
        public Guid SectionId { get; set; }
        public IList<SelectListItem> SectionList { get; set; }
        [Display(Name = "Subject")]
        public Guid SubjectId { get; set; }
        public IList<SelectListItem> SubjectList { get; set; }
        [Display(Name = "Exam")]
        public Guid ExamId { get; set; }
        public IList<SelectListItem> ExamList { get; set; }
        private void PopulateDropdownList()
        {
            AcademicYearList = ModelBuilder.GetAcademicYearList();
            CourseList = new List<SelectListItem>();
            SectionList = new List<SelectListItem>();
            SubjectList = new List<SelectListItem>();
            ExamList = new List<SelectListItem>();
        }
    }

    public class StudentMarks
    {
        internal MarksModelBuilder ModelBuilder;
        public StudentMarks()
        {
            ModelBuilder = new MarksModelBuilder();
        }
        public Guid StudentId { get; set; }
        public Guid SectionId { get; set; }
        public Guid AcademicYearId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ExamId { get; set; }
        public List<MarkDistribution> StudentMark { get; set; }
        public bool Present { get; set; }
    }

    public class MarkDistribution
    {
        public string Name { get; set; }
        public int Mark { get; set; }
    }
}