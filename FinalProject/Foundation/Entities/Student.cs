using System;
using System.Collections.Generic;
using DataAccessLayer.Library;
using Foundation.Library.Enums;

namespace Foundation.Library.Entities
{
    public class Student : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int RollNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthCertificateNo { get; set; }
        public string NationalIdentificationNo { get; set; }
        public Gender Gender { get; set; }
        public Religion Religion { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public string MobileNo { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAlternativeText { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Nationality { get; set; }
        public DateTime YearOfEnroll { get; set; }
        public virtual Parents Parents { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual Registration Registration { get; set; }
        public bool Status { get; set; }
    }
}