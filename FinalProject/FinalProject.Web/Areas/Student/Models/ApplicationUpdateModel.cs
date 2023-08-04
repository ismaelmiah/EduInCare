using System;
using FinalProject.Web.Areas.Student.Models.ModelBuilder;
using Foundation.Library.Enums;

namespace FinalProject.Web.Areas.Student.Models
{
    public class ApplicationUpdateModel
    {
        internal ApplicantModelBuilder ModelBuilder;
        public ApplicationUpdateModel()
        {
            ModelBuilder = new ApplicantModelBuilder();
        }

        public Guid Id { get; set; }
        public string StatusComment { get; set; }

        public void RejectApplication()
        {
            ModelBuilder.RejectStudentApplication(this);
        }
        public void ApproveApplication()
        {
            ModelBuilder.ApproveStudentApplication(this);
        }
    }
}