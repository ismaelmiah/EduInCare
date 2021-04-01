using System;
using System.Collections.Generic;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Designation: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public virtual JobInfo JobInfo { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}