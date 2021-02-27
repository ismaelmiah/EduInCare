using Autofac;
using Foundation.Services;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Areas.Admin.Models
{
    public class HeaderModel
    {
        private readonly IHeaderService _service;
        public HeaderModel(IHeaderService headerService)
        {
            _service = headerService;
        }

        public HeaderModel()
        {
            _service = Startup.AutofacContainer.Resolve<IHeaderService>();
        }

        public string Heading { get; set; }
        public IFormFile CoverPhoto { get; set; }
    }
}
