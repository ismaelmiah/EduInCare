using FinalProject.Web.Areas.Student.Models.ModelBuilder;
using Foundation.Library.Entities;

namespace FinalProject.Web.Areas.Student.Models
{
    public class ApplicationViewModel
    {
        internal ApplicantModelBuilder ModelBuilder;
        public ApplicationViewModel()
        {
            ModelBuilder = new ApplicantModelBuilder();
        }

        public Applicants Applicants { get; set; }
    }
}