using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class ExamRules : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid GradeId { get; set; }
        public Grade Grade { get; set; }
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        public double TotalExamMarks { get; set; }
        public double PassMarks { get; set; }
    }
}