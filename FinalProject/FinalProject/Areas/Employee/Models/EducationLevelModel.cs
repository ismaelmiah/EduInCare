using System;
using System.Collections;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class EducationLevelModel
    {
        internal EducationLevelModelBuilder ModelBuilder;
        public EducationLevelModel()
        {
            ModelBuilder = new EducationLevelModelBuilder();
        }

        public Guid Id { get; set; }
        public string EducationLevelName { get; set; }
    }
}