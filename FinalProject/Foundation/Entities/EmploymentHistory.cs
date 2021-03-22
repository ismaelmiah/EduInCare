using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class EmploymentHistory : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public string Designation { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}