using Autofac;
using Foundation.Services;

namespace FinalProject.Areas.Admin.Models
{
    public class AdvertiseModel
    {
        private readonly IAdvertiseService _service;

        public AdvertiseModel(IAdvertiseService service)
        {
            _service = service;
        }

        public AdvertiseModel()
        {
            _service = Startup.AutofacContainer.Resolve<IAdvertiseService>();
        }

        public string Title { get; set; } = "This is Advertise Section";
        public string ActionUrl { get; set; } = "/";
    }
}