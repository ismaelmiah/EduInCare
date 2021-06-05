using System;
using DataAccessLayer.Library;
using Foundation.Library.Enums;
using Membership.Library.Entities;

namespace Foundation.Library.Entities
{

    /// <summary>
    /// Teacher Is A Employee
    /// Each Teacher Is A User
    /// Each Teacher Has One Section To-Advise
    /// </summary>
    public class Employee : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public RoleType Role { get; set; }
        public string CardId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nid { get; set; }
        public string MobileNo { get; set; }
        public Guid DesignationId { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Religion Religion { get; set; }
        public DateTime JoinOfDate { get; set; }
        public virtual Designation Designation { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime LeavingDate { get; set; }
        public DateTime BirthDate { get; set; }
        public WorkShift? WorkShift { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAlternativeText { get; set; }
        public string Qualifications { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public virtual Section Section { get; set; }
        //public virtual Guid SubjectId { get; set; }
        //public virtual Subject Subject { get; set; }
    }
}