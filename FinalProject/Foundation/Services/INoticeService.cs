using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface INoticeService
    {
        void CreateNotice(Notice notice);
        IList<Notice> GetAllNotices();
        void RemoveNotice(Guid id);
    }
}