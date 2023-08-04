using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class SectionRepository : Repository<Section, Guid, WebsiteContext>, ISectionRepository
    {
        public SectionRepository(WebsiteContext context) : base(context)
        {
        }
    }
}