using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Advertise : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ActionUrl { get; set; }
        public bool IsActive { get; set; }
    }
}