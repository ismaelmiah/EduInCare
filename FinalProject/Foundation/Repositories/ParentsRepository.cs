using System;
using DataAccessLayer;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class ParentsRepository : Repository<Parents, Guid, WebsiteContext>, IParentsRepository
    {
        public ParentsRepository(WebsiteContext context) : base(context)
        {
        }
    }
}