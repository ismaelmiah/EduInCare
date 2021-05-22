using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Newtonsoft.Json;

namespace FinalProject.Web.Areas.Administrative.Models.ModelBuilder
{
    public class HomePageModelBuilder : BaseModel
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

        public async Task SaveHomePage(HomePageModel model)
        {
            await SaveSliders(model.Sliders);
            await SaveFeatures(model.FeatureInfos);
            await SaveFacilities(model.FacilitiesModel);
            await SaveEvents(model.EventsModel);
            await SaveTestimonials(model.TestimonialsModel);
        }

        private async Task SaveSliders(IList<SliderModel> model)
        {
            var sliders = _sliderService.GetList();
            foreach (var item in sliders)
            {
                _sliderService.Delete(item.Id);
            }
            foreach (var item in model)
            {
                if (item.SlideImage != null)
                {
                    var slider = new Sliders
                    {
                        ImageUrl = StoreFile(item.SlideImage).filePath,
                        SubTitle = item.SubHeading,
                        Title = item.Heading
                    };
                    _sliderService.Create(slider);
                }
            }
        }

        private async Task SaveFeatures(IList<FeatureInfoModel> model)
        {
            var features = _featureInfoService.GetList();
            foreach (var item in features)
            {
                _featureInfoService.Delete(item.Id);
            }
            var feature = new FeatureInfos
            {
                Info = JsonConvert.SerializeObject(model)
            };
            _featureInfoService.Create(feature);
        }

        private async Task SaveFacilities(FacilitiesModel model)
        {
            var facilities = _facilityService.GetList();
            foreach (var item in facilities)
            {
                _facilityService.Delete(item.Id);
            }
            var facility = new Facility
            {
                Facilities = JsonConvert.SerializeObject(model.FeatureInfos)
            };
            _facilityService.Create(facility);
        }

        private async Task SaveEvents(EventsModel model)
        {
            var Events = _eventService.GetList();
            foreach (var item in Events)
            {
                _eventService.Delete(item.Id);
            }
            foreach (var item in model.EventItems)
            {
                var events = new Events
                {
                    CoverPhoto = StoreFile(item.EventPhoto).filePath,
                    Description = $"{item.Title},{item.Description}",
                    EventTime = DateTime.UtcNow.ToShortDateString(),
                };
                _eventService.Create(events);
            }
        }

        private async Task SaveTestimonials(TestimonialsModel model)
        {
            var Testimonial = _testimonialService.GetList();
            foreach (var item in Testimonial)
            {
                _testimonialService.Delete(item.Id);
            }
            foreach (var itemModel in model.TestimonialItemModels)
            {
                var testimonial = new Testimonials
                {
                    Comment = itemModel.Description,
                    Writer = $"{itemModel.Name},{itemModel.Subtitle}",
                    Avatar = StoreFile(itemModel.UserPhotoFile).filePath
                };
                _testimonialService.Create(testimonial);
            }
        }

        public (FacilitiesModel facilitiesModel, EventsModel eventsModel, TestimonialsModel testimonialsModel, List<SliderModel> sliderModels, List<FeatureInfoModel> featureInfoModels) BuildHomepage()
        {
            var facility = _facilityService.GetList().FirstOrDefault();
            var eventsItem = _eventService.GetList().Select(x =>
                new EventItemModel { Description = x.Description.Split(',')[0], Title = x.Description.Split(',')[1] }).ToList();

            var testimonials = _testimonialService.GetList().Select(x =>
                new TestimonialItemModel
                {
                    Description = x.Comment,
                    Subtitle = x.Writer.Split(',')[1],
                    Name = x.Writer.Split(',')[0]
                }).ToList();

            var sliders = _sliderService.GetList().Select(x =>
                new SliderModel
                {
                    SubHeading = x.SubTitle,
                    Heading = x.Title,
                    ImageUrl = FormatImageUrl(x.ImageUrl)
                }).ToList();

            var features = _featureInfoService.GetList().FirstOrDefault();

            //var homepage = new HomePageModel
            //{
            //    FacilitiesModel = new FacilitiesModel
            //            //    {
            //            FeatureInfos = facility.Facilities != null ? JsonConvert.DeserializeObject<List<FeatureInfoModel>>(facility.Facilities) : new List<FeatureInfoModel>()
            //                },
            //                EventsModel = new EventsModel
            //                {
            //                    EventItems = eventsItem.Count > 0 ? eventsItem : new List<EventItemModel>()
            //    },
            //                TestimonialsModel = new TestimonialsModel()
            //    {
            //        TestimonialItemModels = testimonials.Count > 0 ? testimonials : new List<TestimonialItemModel>()
            //                },
            //                Sliders = sliders.Count > 0 ? sliders : new List<SliderModel>(),
            //                FeatureInfos = facility.Facilities != null ? JsonConvert.DeserializeObject<List<FeatureInfoModel>>(features.Info) : new List<FeatureInfoModel>()
            //};
            return (
                new FacilitiesModel
                {
                    FeatureInfos = facility != null
                        ? JsonConvert.DeserializeObject<List<FeatureInfoModel>>(facility.Facilities)
                        : new List<FeatureInfoModel>()
                }, new EventsModel
                {
                    EventItems = eventsItem.Count > 0 ? eventsItem : new List<EventItemModel>()
                },
                new TestimonialsModel()
                {
                    TestimonialItemModels = testimonials.Count > 0 ? testimonials : new List<TestimonialItemModel>()
                }, sliders.Count > 0 ? sliders : new List<SliderModel>(),
                features != null
                    ? JsonConvert.DeserializeObject<List<FeatureInfoModel>>(features.Info)
                    : new List<FeatureInfoModel>());
        }
    }
}