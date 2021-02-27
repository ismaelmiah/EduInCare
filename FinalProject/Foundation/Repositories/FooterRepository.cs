using System;
using DataAccessLayer;
using Foundation.Contexts;
using Foundation.Entities;

namespace Foundation.Repositories
{
    public class FooterRepository : Repository<Footer, Guid, WebsiteContext>, IFooterRepository
    {
        public FooterRepository(WebsiteContext context) : base(context)
        {
        }
    }
}