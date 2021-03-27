using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class EmployeeImage : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}