using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Footer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Copyright { get; set; }
        public bool ShowCopyright { get; set; }
    }
}