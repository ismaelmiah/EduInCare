using Autofac;
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
        }

        public string Copyright { get; set; } = "All Rights reserved by &copy; Ismail Final Year Project";
    }
}