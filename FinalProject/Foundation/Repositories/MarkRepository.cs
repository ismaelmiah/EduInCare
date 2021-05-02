using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class MarkRepository : Repository<Mark, Guid, WebsiteContext>, IMarkRepository
    {
        public MarkRepository(WebsiteContext context) : base(context)
        {
        }
    }
}