using System;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class GradeModel
    {
        internal GradeModelBuilder ModelBuilder;
        public GradeModel()
        {
            ModelBuilder = new GradeModelBuilder();
        }

        public Guid Id { get; set; }
    }
}