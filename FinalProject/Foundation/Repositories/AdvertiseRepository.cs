using System;
using DataAccessLayer;
using Foundation.Contexts;
using Foundation.Entities;

namespace Foundation.Repositories
{
    public class AdvertiseRepository : Repository<Advertise, Guid, WebsiteContext>, IAdvertiseRepository
    {
        public AdvertiseRepository(WebsiteContext context) : base(context)
        {
        }
    }
}