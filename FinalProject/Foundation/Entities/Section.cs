using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    /// <summary>
    /// Each Section Has One Course
    /// Each Section Has One adviser
    /// </summary>
    public class Section : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public Guid TeacherId { get; set; }
        public virtual Employee Employee { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public virtual Registration Registration { get; set; }
    }
}