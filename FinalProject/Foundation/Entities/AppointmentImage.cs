using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class AppointmentImage : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string AlternativeText { get; set; }
        public Guid JobInfoId { get; set; }
        public virtual JobInfo JobInfo { get; set; }
    }
}