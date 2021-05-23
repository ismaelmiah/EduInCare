using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class StudentAttendance : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string AttendanceInfo { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}