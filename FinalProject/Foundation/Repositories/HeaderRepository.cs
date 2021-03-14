using System;
using DataAccessLayer;
using Foundation.Library.Entities;
using Foundation.Library.Contexts;

namespace Foundation.Library.Repositories
{
    public class HeaderRepository : Repository<Header, Guid, WebsiteContext>, IHeaderRepository
    {
        public HeaderRepository(WebsiteContext context) : base(context)
        {
        }
    }
}