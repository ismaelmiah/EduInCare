using System;
using DataAccessLayer;

namespace Foundation.Entity
{
    public class Footer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Copyright { get; set; }
    }
}