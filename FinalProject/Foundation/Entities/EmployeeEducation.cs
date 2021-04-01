using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Enums;

namespace Foundation.Library.Entities
{
    public class EmployeeEducation : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public Guid ExamTitleId { get; set; }
        public ExamTitle ExamTitle { get; set; }
        public string Major { get; set; }
        public string InstituteName { get; set; }
        public ResultType ResultType { get; set; }
        public float Cgpa { get; set; }
        public int Scale { get; set; }
        public float Marks { get; set; }
        public string PassingYear { get; set; }
        public int Duration { get; set; }
        public string Achievement { get; set; }
        //public Guid EmployeeId { get; set; }
        //public Employee Employee { get; set; }
    }
}