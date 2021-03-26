using System;
using DataAccessLayer;

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
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public bool ExcludeInResult { get; set; }
    }
}