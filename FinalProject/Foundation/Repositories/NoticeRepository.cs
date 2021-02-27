using System;
using DataAccessLayer;
using Foundation.Contexts;
using Foundation.Entities;

namespace Foundation.Repositories
{
    public class NoticeRepository : Repository<Notice, Guid, WebsiteContext>, INoticeRepository
    {
        public NoticeRepository(WebsiteContext context) : base(context)
        {
        }
    }
}