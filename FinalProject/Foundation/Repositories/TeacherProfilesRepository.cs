using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class TeacherProfilesRepository : Repository<TeacherProfiles, Guid, WebsiteContext>, ITeacherProfilesRepository
    {
        public TeacherProfilesRepository(WebsiteContext context) : base(context)
        {
        }
    }
}