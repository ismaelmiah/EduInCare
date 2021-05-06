using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Testimonials : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Writer { get; set; }
        public string Comment { get; set; }
        public string Avatar { get; set; }
        public int Order { get; set; }
    }
}