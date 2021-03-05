using System;
using DataAccessLayer;

namespace Foundation.Entities
{
    public class Footer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Copyright { get; set; }
        public bool ShowCopyright { get; set; }
    }
}