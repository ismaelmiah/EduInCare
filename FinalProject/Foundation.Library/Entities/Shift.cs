using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    /// <summary>
    /// Each Shift Has Registered Student
    /// </summary>
    public class Shift: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Registration Registration { get; set; }
    }
}