using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Parents : IEntity<Guid>
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
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}