using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class AcademicYear : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsOpenForAdmission { get; set; }
        public bool Status { get; set; }
    }
}