using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Address : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public Guid? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}