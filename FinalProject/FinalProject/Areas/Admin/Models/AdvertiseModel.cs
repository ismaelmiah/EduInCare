using Autofac;
using Foundation.Entities;
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
            CurrentAdvertise();
        }

        public string Title { get; set; } = "This is Advertise Section";
        public string ActionUrl { get; set; } = "/";
        public bool IsActive { get; set; }

        public void SaveAdvertise()
        {
            var advertise = ConvertToEntity();
            _service.CreateAdvertise(advertise);
        }

        public void CurrentAdvertise()
        {
            var advertises = _service.GetAdvertises();
            foreach (var advertise in advertises)
            {
                ActionUrl = advertise.ActionUrl;
                Title = advertise.Title;
                IsActive = advertise.IsActive;
            }
        }
        private Advertise ConvertToEntity()
        {
            return new Advertise
            {
                ActionUrl = ActionUrl,
                Title = Title,
                IsActive = IsActive
            };
        }
    }
}