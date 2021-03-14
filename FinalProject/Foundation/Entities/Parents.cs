using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class StudentParents : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string FatherName { get; set; }
        public string FatherMobileNo { get; set; }
        public string FatherOccupation { get; set; }
        public double FatherAnnualIncome { get; set; }
        public string MotherName { get; set; }
        public string MotherMobileNo { get; set; }
        public string MotherOccupation { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobileNo { get; set; }
    }
}