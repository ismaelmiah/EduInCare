using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Administrative.Models.ModelBuilder
{
    public class SliderModelBuilder
    {
        private readonly ISliderService _sliderService;

        public SliderModelBuilder(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public SliderModelBuilder()
        {
            _sliderService = Startup.AutofacContainer.Resolve<ISliderService>();
        }
    }
}