using System;
using FinalProject.Web.Areas.Administrative.Models.ModelBuilder;

namespace FinalProject.Web.Areas.Administrative.Models
{
    public class SliderModel
    {
        internal SliderModelBuilder ModelBuilder;

        public SliderModel()
        {
            ModelBuilder = new SliderModelBuilder();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
    }
}