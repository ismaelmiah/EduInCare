using System;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class ExamRulesModel
    {
        internal ExamRulesModelBuilder ModelBuilder;
        public ExamRulesModel()
        {
            ModelBuilder = new ExamRulesModelBuilder();
        }

        public Guid Id { get; set; }
    }
}