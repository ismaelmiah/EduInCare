using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class ExamTitle : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string TitleName { get; set; }
        public Guid EducationLevelId { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }
        public virtual  EmployeeEducation EmployeeEducation { get; set; }
    }
}