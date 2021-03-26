using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Image : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}