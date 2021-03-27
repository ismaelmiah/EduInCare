using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class EducationLevelRepository : Repository<EducationLevel, Guid, WebsiteContext>, IEducationLevelRepository
    {
        public EducationLevelRepository(WebsiteContext context) : base(context)
        {
        }
    }
}