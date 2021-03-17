using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class HeaderImage : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string AlternativeText { get; set; }
        public Guid HeaderId { get; set; }
        public Header Header { get; set; }
    }
}