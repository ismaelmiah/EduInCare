using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    /// <summary>
    /// Each Group Has One Course
    /// </summary>
    public class Group : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public virtual Course Course { get; set; }
    }
}