using System;
using DataAccessLayer;

namespace Foundation.Entities
{
    public class Header : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public virtual Image Image { get; set; }
        public bool ShowBannerImage { get; set; }
    }
}