using System;
using DataAccessLayer;
using DataAccessLayer.Library;

namespace Foundation.Library.Entities
{
    public class EducationLevel : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string EducationLevelName { get; set; }
        public virtual EmployeeEducation EmployeeEducation { get; set; }
        public virtual ExamTitle ExamTitle { get; set; }
    }
}