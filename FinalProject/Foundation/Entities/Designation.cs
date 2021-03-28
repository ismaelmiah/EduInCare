using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Designation: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual JobInfo JobInfo { get; set; }
    }
}