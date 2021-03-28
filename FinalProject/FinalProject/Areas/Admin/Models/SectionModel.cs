using FinalProject.Web.Areas.Admin.Models.ModelBuilder;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class SectionModel
    {
        internal SectionModelBuilder ModelBuilder;

        public SectionModel()
        {
            ModelBuilder = new SectionModelBuilder();
        }
    }
}