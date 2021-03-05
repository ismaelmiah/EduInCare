using System.Linq;
using Autofac;
using Foundation.Entities;
using Foundation.Services;

namespace FinalProject.Areas.Admin.Models
{
    public class FooterModel
    {
        private readonly IFooterService _service;

        public FooterModel(IFooterService footerService)
        {
            _service = footerService;
        }

        public FooterModel()
        {
            _service = Startup.AutofacContainer.Resolve<IFooterService>();
            CurrentFooter();
        }

        public string Copyright { get; set; }
        public bool ShowCopyrightText { get; set; }

        public void SaveFooter()
        {
            var model = ConvertToEntity();
            _service.AddFooter(model);
        }

        public void CurrentFooter()
        {
            var footers = _service.GetFooter();
            foreach (var footer in footers)
            {
                Copyright = footer.Copyright;
                ShowCopyrightText = footer.ShowCopyright;
            }
        }
        private Footer ConvertToEntity()
        {
            return new Footer
            {
                Copyright = Copyright,
                ShowCopyright = ShowCopyrightText
            };
        }
    }
}