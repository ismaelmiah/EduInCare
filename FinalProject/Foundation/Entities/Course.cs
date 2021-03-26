using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Course : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public Guid? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        //TODO: Course & Department Might be Many TO Many Relationship
    }
}