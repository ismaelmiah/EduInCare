using System;
using System.Collections.Generic;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    /// <summary>
    /// Each AcademicYear Has One Registration (If Status TRUE)
    /// </summary>
    public class AcademicYear : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsOpenForAdmission { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}