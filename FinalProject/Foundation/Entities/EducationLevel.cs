using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class EducationLevel : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string EducationLevelName { get; set; }
    }
}