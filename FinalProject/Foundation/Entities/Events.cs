using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Events : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string EventTime { get; set; }
        public string CoverPhoto { get; set; }
        public string CoverVideo { get; set; }
        public string Description { get; set; }
    }
}