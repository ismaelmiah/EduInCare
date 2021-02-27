using System.Collections;
using System.Collections.Generic;
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
        public IList<NoticeViewModel> NoticeList { get; set; }
    }

    public class NoticeViewModel
    {
        public string Title { get; set; } = "This is Notice Title";
        public string Description { get; set; } = "This is Notice Description";
    }
}