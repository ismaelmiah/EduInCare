using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Address : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}