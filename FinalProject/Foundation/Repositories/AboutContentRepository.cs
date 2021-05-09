using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class AboutContentRepository : Repository<AboutContent, Guid, WebsiteContext>, IAboutContentRepository
    {
        public AboutContentRepository(WebsiteContext context) : base(context)
        {
        }
    }
}