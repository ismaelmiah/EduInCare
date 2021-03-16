using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Header : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public bool ShowBannerImage { get; set; }
    }
}