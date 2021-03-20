using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Address : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public Student Student { get; set; }
    }
}