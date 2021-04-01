using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    /// <summary>
    /// Each Job Info Has One Designation
    /// Each Job Info belongs To One Employee
    /// </summary>
    public class JobInfo : IEntity<Guid>
    {
        public Guid Id { get; set; }
        //public Guid DesignationId { get; set; }
        //public Designation Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public decimal Salary { get; set; }
        public int TotalLeave { get; set; }
        public AppointmentImage Appointment { get; set; }
        //public Guid EmployeeId { get; set; }
        //public Employee Employee { get; set; }
    }
}