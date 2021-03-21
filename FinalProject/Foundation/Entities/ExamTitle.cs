using System;
using DataAccessLayer;

namespace Foundation.Library.Entities
{
    public class ExamTitle : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string TitleName { get; set; }
        public int EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }
    }
}