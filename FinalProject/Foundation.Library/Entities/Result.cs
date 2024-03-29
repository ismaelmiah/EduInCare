﻿using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Result : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid AcademicYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public Guid SectionId { get; set; }
        public virtual Section Section { get; set; }
        public Guid ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public double TotalMarks { get; set; }
        public string Grade { get; set; }
        public double Point { get; set; }
    }
}