using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class RecordMeta : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedLast { get; set; }
    }
}