using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Group : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Course Course { get; set; }
    }
}