using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Administrative.Models.ModelBuilder
{
    public class HomePageModelBuilder
    {
        private readonly ISliderService _sliderService;
        private readonly IEventService _eventService;

        public HomePageModelBuilder(ISliderService sliderService, IEventService eventService)
        {
            _sliderService = sliderService;
            _eventService = eventService;
        }

        public HomePageModelBuilder()
        {
            _sliderService = Startup.AutofacContainer.Resolve<ISliderService>();
        }

        public void SaveHomePage(HomePageModel model)
        {
            
        }
    }
}