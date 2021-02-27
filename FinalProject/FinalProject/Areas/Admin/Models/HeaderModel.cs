using System;
using Autofac;
using Foundation.Entities;
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

        public bool ShowBannerImage { get; set; }
        public IFormFile BannerImage { get; set; }

        public void SaveHeader(HeaderModel model)
        {
            var header = model.ConvertToEntity(model);
            _service.AddHeaderImage(header);
        }

        private Header ConvertToEntity(HeaderModel model)
        {
            return new Header
            {
                Image = new Image
                {

                },
            };
        }
    }
}
