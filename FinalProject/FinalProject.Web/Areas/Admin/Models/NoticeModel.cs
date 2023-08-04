using System.Collections.Generic;
using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models
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
            GetAllNotices();
        }
        public IList<NoticeViewModel> NoticeList { get; set; }

        public void SaveNotice(Notice notice)
        {
            _service.CreateNotice(notice);
        }

        private void GetAllNotices()
        {
            var notices = _service.GetAllNotices();
            NoticeList = new List<NoticeViewModel>();
            foreach (var notice in notices)
            {
                NoticeList.Add(new NoticeViewModel()
                {
                    Title = notice.Title,
                    Description = notice.Description,
                    IsActive = notice.IsActive
                });
            }
        }
    }

    public class NoticeViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public void SaveNotice()
        {

            var model = ConvertToEntity();
            new NoticeModel().SaveNotice(model);
        }
        public Notice ConvertToEntity()
        {
            return new Notice
            {
                Title = Title,
                Description = Description,
                IsActive = IsActive
            };
        }
    }
}