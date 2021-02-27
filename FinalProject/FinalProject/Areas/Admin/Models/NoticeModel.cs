using Autofac;
using Foundation.Services;

namespace FinalProject.Areas.Admin.Models
{
    public class NoticeModel
    {
        private readonly INoticeService _service;

        public NoticeModel(INoticeService noticeService)
        {
            _service = noticeService;
        }

        public NoticeModel()
        {
            _service = Startup.AutofacContainer.Resolve<INoticeService>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}