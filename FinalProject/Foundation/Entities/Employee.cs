using System;
using System.Collections.Generic;
using DataAccessLayer;
using Foundation.Library.Enums;

namespace Foundation.Library.Entities
{
    public class Employee : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Gender Gender { get; set; }
        public string Nid { get; set; }
        public string MobileNo { get; set; }
        public string MaritalStatus { get; set; }
        public Religion Religion { get; set; }
        public DateTime JoinOfDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAlternativeText { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<EmployeeEducation> EmployeeEducation { get; set; }
        public ICollection<EmploymentHistory> EmploymentHistory { get; set; }
        public ICollection<JobInfo> JobInfo { get; set; }
    }
}