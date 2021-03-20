using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Course : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Student> Students { get; set; }
        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}