using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class FeatureInfoRepository : Repository<FeatureInfos, Guid, WebsiteContext>, IFeatureInfoRepository
    {
        public FeatureInfoRepository(WebsiteContext context) : base(context)
        {
        }
    }
}