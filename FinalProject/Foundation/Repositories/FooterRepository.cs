using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Entities;
using Foundation.Library.Contexts;

namespace Foundation.Library.Repositories
{
    public class FooterRepository : Repository<Footer, Guid, WebsiteContext>, IFooterRepository
    {
        public FooterRepository(WebsiteContext context) : base(context)
        {
        }
    }
}