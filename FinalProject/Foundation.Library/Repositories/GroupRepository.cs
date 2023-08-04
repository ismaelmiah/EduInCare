using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class GroupRepository : Repository<Group, Guid, WebsiteContext>, IGroupRepository
    {
        public GroupRepository(WebsiteContext context) : base(context)
        {
        }
    }
}