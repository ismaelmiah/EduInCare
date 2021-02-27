using System;
using DataAccessLayer;

namespace Foundation.Entities
{
    public class Post : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}