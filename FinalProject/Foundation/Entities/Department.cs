using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Department : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}