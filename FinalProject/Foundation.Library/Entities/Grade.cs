using System;
using System.Collections.Generic;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Grade : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Rule { get; set; }
        public virtual ICollection<ExamRules> ExamRules { get; set; }
    }
}