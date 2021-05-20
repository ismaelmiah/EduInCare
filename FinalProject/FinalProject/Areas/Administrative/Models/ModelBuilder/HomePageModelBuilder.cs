using System.Collections.Generic;
using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Administrative.Models.ModelBuilder
{
    public class HomePageModelBuilder
    {
        private readonly ISliderService _sliderService;
        private readonly IEventService _eventService;
        private readonly IFacilityService _facilityService;
        private readonly IFeatureInfoService _featureInfoService;
        private readonly ITestimonialService _testimonialService;

        public HomePageModelBuilder(
            ISliderService sliderService,
            IEventService eventService,
            IFacilityService facilityService,
            IFeatureInfoService featureInfoService,
            ITestimonialService testimonialService)
        {
            _sliderService = sliderService;
            _eventService = eventService;
            _facilityService = facilityService;
            _featureInfoService = featureInfoService;
            _testimonialService = testimonialService;
        }

        public HomePageModelBuilder()
        {
            _sliderService = Startup.AutofacContainer.Resolve<ISliderService>();
            _eventService = Startup.AutofacContainer.Resolve<IEventService>();
            _facilityService = Startup.AutofacContainer.Resolve<IFacilityService>();
            _featureInfoService = Startup.AutofacContainer.Resolve<IFeatureInfoService>();
            _testimonialService = Startup.AutofacContainer.Resolve<ITestimonialService>();
        }

        public void SaveHomePage(HomePageModel model)
        {
            var slider = ConvertToSlider(model.Sliders);
            _sliderService.Create(slider);
            var feature = ConvertToFeature(model.FeatureInfos);
            _featureInfoService.Create(feature);
            var facility = ConvertToFacility(model.FacilitiesModel);
            _facilityService.Create(facility);
            var events = ConvertToEvent(model.EventsModel);
            _eventService.Create(events);
            var testimonial = ConvertToTestimonial(model.TestimonialsModel);
            _testimonialService.Create(testimonial);
        }

        private Testimonials ConvertToTestimonial(TestimonialsModel model)
        {
            var testimonial = new Testimonials();

            throw new System.NotImplementedException();
        }

        private Events ConvertToEvent(EventsModel model)
        {
            throw new System.NotImplementedException();
        }

        private Facility ConvertToFacility(FacilitiesModel model)
        {
            throw new System.NotImplementedException();
        }

        private FeatureInfos ConvertToFeature(IList<FeatureInfoModel> model)
        {
            throw new System.NotImplementedException();
        }

        private Sliders ConvertToSlider(IList<SliderModel> model)
        {
            throw new System.NotImplementedException();
        }
    }
}