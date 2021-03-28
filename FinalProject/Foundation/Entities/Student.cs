using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class Student : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthCertificateNo { get; set; }
        public string NationalIdentificationNo { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAlternativeText { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Nationality { get; set; }
        public DateTime YearOfEnroll { get; set; }
        public virtual Parents Parents { get; set; }
        public virtual Registration Registration { get; set; }
    }
}