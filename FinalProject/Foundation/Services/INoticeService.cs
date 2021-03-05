using System;
using System.Collections;
using System.Collections.Generic;
using Foundation.Entities;

namespace Foundation.Services
{
    public interface INoticeService
    {
        void CreateNotice(Notice notice);
        IList<Notice> GetAllNotices();
        void RemoveNotice(Guid id);
    }
}