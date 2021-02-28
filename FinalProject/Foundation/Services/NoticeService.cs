using System;
using System.Collections.Generic;
using Foundation.Entities;
using Foundation.UnitOfWorks;

namespace Foundation.Services
{
    public class NoticeService : INoticeService
    {
        private readonly IWebsiteUnitOfWork _websiteUnit;

        public NoticeService(IWebsiteUnitOfWork website)
        {
            _websiteUnit = website;
        }

        public void CreateNotice(Notice notice)
        {
            _websiteUnit.Notice.Add(notice);
            _websiteUnit.Save();
        }

        public IList<Notice> GetAllNotices()
        {
            return _websiteUnit.Notice.GetAll();
        }

        public void RemoveNotice(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}