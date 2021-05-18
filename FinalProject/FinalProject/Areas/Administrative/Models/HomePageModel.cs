using System;
using System.Collections.Generic;
using FinalProject.Web.Areas.Administrative.Models.ModelBuilder;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Web.Areas.Administrative.Models
{
    public class HomePageModel
    {
        internal HomePageModelBuilder ModelBuilder;

        public HomePageModel()
        {
            ModelBuilder = new HomePageModelBuilder();
            FacilitiesModel = new FacilitiesModel();
            EventsModel = new EventsModel();
            TestimonialsModel = new TestimonialsModel();
        }

        public IList<SliderModel> Sliders { get; set; }
        public IList<FeatureInfoModel> FeatureInfos { get; set; }
        public FacilitiesModel FacilitiesModel { get; set; }
        public EventsModel EventsModel { get; set; }
        public TestimonialsModel TestimonialsModel { get; set; }
    }

    public class SliderModel
    {
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public IFormFile SlideImage { get; set; }
    }

    public class FeatureInfoModel
    {
        public string Heading { get; set; }
        public string Description { get; set; }
    }

    public class FacilitiesModel
    {
        public FacilitiesModel()
        {
            FeatureInfos = new List<FeatureInfoModel>();
        }
        public string Heading { get; set; }
        public string Description { get; set; }
        public List<FeatureInfoModel> FeatureInfos { get; set; }
    }

    public class EventsModel
    {
        public EventsModel()
        {
            EventItems = new List<EventItemModel>();
        }
        public string Heading { get; set; }
        public string Description { get; set; }
        public List<EventItemModel> EventItems { get; set; }
    }

    public class EventItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile EventPhoto { get; set; }
    }

    public class TestimonialsModel
    {
        public TestimonialsModel()
        {
            TestimonialItemModels = new List<TestimonialItemModel>();
        }
        public string Heading { get; set; }
        public string Description { get; set; }
        public List<TestimonialItemModel> TestimonialItemModels { get; set; }
    }

    public class TestimonialItemModel
    {
        public string Name { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public IFormFile UserPhotoFile { get; set; }
    }
}