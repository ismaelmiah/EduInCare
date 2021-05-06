using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class TeacherProfiles : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Qualifications { get; set; }
        public string SocialMedia { get; set; }
    }
}