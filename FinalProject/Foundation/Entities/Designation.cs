using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Designation: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}