using System;
using System.Collections.Generic;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Exam : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public string MarksDistributionTypes { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<ExamRules> ExamRules { get; set; }
    }
}