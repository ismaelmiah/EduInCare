using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class EmployeeAttendance : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}