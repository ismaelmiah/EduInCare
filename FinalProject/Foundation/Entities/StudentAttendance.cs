using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class StudentAttendance : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public bool IsPresent { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}