using System;
using DataAccessLayer.Library;
using Foundation.Library.Enums;

namespace Foundation.Library.Entities
{
    public class Applicants : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
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
        public Status Status { get; set; }
        public Guid? StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public string Email { get; set; }
        public RecordMeta RecordMeta { get; set; }
    }
}