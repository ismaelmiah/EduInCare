using System;
using DataAccessLayer;

namespace Foundation.Entity
{
    public class Header : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public virtual Image Image { get; set; }
        public string CoverTitle { get; set; }
    }
}