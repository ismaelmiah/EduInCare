using Autofac;
using Foundation.Services;

namespace FinalProject.Areas.Admin.Models
{
    public class PostModel
    {
        private readonly IPostService _service;

        public PostModel(IPostService service)
        {
            _service = service;
        }

        public PostModel()
        {
            _service = Startup.AutofacContainer.Resolve<IPostService>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}