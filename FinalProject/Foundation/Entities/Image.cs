using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Image : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string AlternativeText { get; set; }
    }
}