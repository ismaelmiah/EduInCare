﻿using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class HeaderModel : BaseModel
    {
        private readonly IHeaderService _service;
        public HeaderModel(IHeaderService headerService)
        {
            _service = headerService;
        }

        public HeaderModel()
        {
            _service = Startup.AutofacContainer.Resolve<IHeaderService>();
            CurrentHeader();
        }

        public bool ShowBannerImage { get; set; }
        public IFormFile BannerImage { get; set; }
        public string ImagePath { get; set; }

        public void SaveHeader()
        {
            var header = ConvertToEntity();
            _service.AddHeaderImage(header);
        }

        public void CurrentHeader()
        {
            var headers = _service.GetHeader();
            foreach (var header in headers)
            {
                ShowBannerImage = header.ShowBannerImage;
            }
        }
        private Header ConvertToEntity()
        {
            var (fileName, filePath) = StoreFile(BannerImage);
            return new Header
            {
                ShowBannerImage = ShowBannerImage,
            };
        }
    }
}
