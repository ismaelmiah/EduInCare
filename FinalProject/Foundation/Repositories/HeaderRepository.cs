using System;
using DataAccessLayer;
using Foundation.Contexts;
using Foundation.Entities;

namespace Foundation.Repositories
{
    public class HeaderRepository : Repository<Header, Guid, WebsiteContext>, IHeaderRepository
    {
        public HeaderRepository(WebsiteContext context) : base(context)
        {
        }
    }
}