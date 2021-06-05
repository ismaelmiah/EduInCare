using System;
using DataAccessLayer.Library;
using System.Collections.Generic;

namespace Foundation.Library.Entities
{
    /// <summary>
    /// Each Subject Has One Course
    /// </summary>
    public class Subject : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Type { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public bool ExcludeInResult { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<ExamRules> ExamRules { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        //public virtual ICollection<Employee> Teachers { get; set; }
    }
}