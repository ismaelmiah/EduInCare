using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Administrative.Models.ModelBuilder
{
    public class HomePageModelBuilder
    {
        private readonly ISliderService _sliderService;

        public HomePageModelBuilder(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public HomePageModelBuilder()
        {
            _sliderService = Startup.AutofacContainer.Resolve<ISliderService>();
        }
    }
}