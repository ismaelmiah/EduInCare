using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Enums;
using Microsoft.AspNetCore.Identity;

namespace Foundation.Library.Entities
{

    /// <summary>
    /// Teacher Is A Employee
    /// Teacher Has Many EmployeeEducation
    /// Teacher Has Many EmploymentHistory
    /// Teacher Has Many JobInfo
    /// Each Teacher Is A User
    /// Each Teacher Has One Section To-Advise
    /// </summary>
    public class Employee : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
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
        public virtual ICollection<EmployeeEducation> EmployeeEducation { get; set; }
        public virtual ICollection<EmploymentHistory> EmploymentHistory { get; set; }
        public virtual ICollection<JobInfo> JobInfo { get; set; }
        public virtual Section Section { get; set; }
    }
}