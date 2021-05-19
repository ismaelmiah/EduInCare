using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class FeatureInfos : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Info { get; set; }
    }
}