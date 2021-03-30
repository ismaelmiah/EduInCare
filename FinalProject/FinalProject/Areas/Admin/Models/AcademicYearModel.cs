using System;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class AcademicYearModel
    {
        internal AcademicYearModelBuilder ModelBuilder;

        public AcademicYearModel()
        {
            ModelBuilder = new AcademicYearModelBuilder();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsOpenForAdmission { get; set; }
        public bool Status { get; set; }
    }
}