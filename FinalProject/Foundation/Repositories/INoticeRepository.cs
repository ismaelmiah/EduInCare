using System;
using DataAccessLayer;
using Foundation.Contexts;
using Foundation.Entities;

namespace Foundation.Repositories
{
    public interface INoticeRepository : IRepository<Notice, Guid, WebsiteContext>
    {

    }
}