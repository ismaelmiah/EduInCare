using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class ClassProfilesRepository : Repository<ClassProfiles, Guid, WebsiteContext>, IClassProfilesRepository
    {
        public ClassProfilesRepository(WebsiteContext context) : base(context)
        {
        }
    }
}