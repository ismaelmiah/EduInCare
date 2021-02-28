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
        }

        public string Title { get; set; } = "This is Advertise Section";
        public string ActionUrl { get; set; } = "/";
        public bool IsActive { get; set; }

        public void SaveAdvertise()
        {
            var advertise = ConvertToEntity();
            _service.CreateAdvertise(advertise);
        }

        public AdvertiseModel CurrentAdvertise()
        {
            var advertises = _service.GetAdvertises();
            var model = new AdvertiseModel();
            foreach (var advertise in advertises)
            {
                model.ActionUrl = advertise.ActionUrl;
                model.Title = advertise.Title;
                model.IsActive = advertise.IsActive;
            }
            return model;
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