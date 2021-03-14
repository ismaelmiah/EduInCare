using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Course : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}