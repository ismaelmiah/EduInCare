using System;
using DataAccessLayer;
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
        public virtual Registration Registration { get; set; }
    }
}