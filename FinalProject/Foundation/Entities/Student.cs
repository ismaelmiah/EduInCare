using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class Student : IEntity<Guid>
    {
        public Guid Id { get; set; }
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
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}