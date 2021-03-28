using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class EmployeeAddress : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}