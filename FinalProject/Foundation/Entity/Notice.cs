using System;
using DataAccessLayer;

namespace Foundation.Entity
{
    public class Notice : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}