using System;
using System.Collections.Generic;
using DataAccessLayer.Library;
using Foundation.Library.Enums;

namespace Foundation.Library.Entities
{
    /// <summary>
    /// Each Registration Has One Student
    /// Each Registration Has One Course
    /// Each Registration Has One Section
    /// Each Registration Has One AcademicYear
    /// Each Registration Has One Shift
    /// </summary>
    public class Registration : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string RegistrationNo { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public Guid SectionId { get; set; }
        public virtual Section Section { get; set; }
        public Guid AcademicYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        public int RollNo { get; set; }
        public string CardNo { get; set; }
        public string BoardRegistrationNo { get; set; }
        public bool IsPromoted { get; set; }
        public string OldRegistrationId { get; set; }
        public bool Status { get; set; }
    }
}