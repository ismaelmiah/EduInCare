using System.Collections.Generic;
using FinalProject.Web.Areas.Administrative.Models;
using FinalProject.Web.Areas.Administrative.Models.ModelBuilder;

namespace FinalProject.Web.Models
{
    public class WebsiteModel
    {
        //public HeaderModel Header { get; set; }
        //public FooterModel Footer { get; set; }
        //public PostModel Post { get; set; }
        //public NoticeModel Notice { get; set; }
        //public AdvertiseModel Advertise { get; set; }

        internal HomePageModelBuilder ModelBuilder;

        public WebsiteModel()
        {
            ModelBuilder = new HomePageModelBuilder();
            var (facilitiesModel, eventsModel, testimonialsModel, sliderModels, featureInfoModels) =
                ModelBuilder.BuildHomepage();
            Sliders = sliderModels;
            EventsModel = eventsModel;
            TestimonialsModel = testimonialsModel;
            FacilitiesModel = facilitiesModel;
            FeatureInfos = featureInfoModels;
        }

        public IList<SliderModel> Sliders { get; set; }
        public IList<FeatureInfoModel> FeatureInfos { get; set; }
        public FacilitiesModel FacilitiesModel { get; set; }
        public EventsModel EventsModel { get; set; }
        public TestimonialsModel TestimonialsModel { get; set; }
    }
}