using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class NoticeRepository : Repository<Notice, Guid, WebsiteContext>, INoticeRepository
    {
        public NoticeRepository(WebsiteContext context) : base(context)
        {
        }
    }
}