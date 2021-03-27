using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class JobInfoRepository : Repository<JobInfo, Guid, WebsiteContext>, IJobInfoRepository
    {
        public JobInfoRepository(WebsiteContext context) : base(context)
        {
        }
    }
}