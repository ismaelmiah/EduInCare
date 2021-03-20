using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class EmployeeImage : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string AlternativeText { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}