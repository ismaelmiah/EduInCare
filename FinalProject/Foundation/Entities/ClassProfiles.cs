using System;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class ClassProfiles : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RoomNo { get; set; }
        public int Capacity { get; set; }
        public string ShortDescription { get; set; }
    }
}