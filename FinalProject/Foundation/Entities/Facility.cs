using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Facility : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Facilities { get; set; }
    }
}