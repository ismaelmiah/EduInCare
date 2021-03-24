using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Registration : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string RegistrationNo { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid CourseId { get; set; }
        public virtual  Course Course { get; set; }
        public Guid SectionId { get; set; }
        public virtual  Section Section { get; set; }
        public Guid AcademicYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        public int RollNo { get; set; }
        public Guid ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
        public string CardNo { get; set; }
        public string BoardRegistrationNo { get; set; }
        public bool IsPromoted { get; set; }
        public string OldRegistrationId { get; set; }
        public bool Status { get; set; }
    }
}