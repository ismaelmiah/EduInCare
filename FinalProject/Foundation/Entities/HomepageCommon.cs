using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class HomepageCommon : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string HeadingsData { get; set; }
    }
}