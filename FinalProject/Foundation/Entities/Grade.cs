using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Grade : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Rule { get; set; }
        public virtual ExamRules ExamRules { get; set; }
    }
}