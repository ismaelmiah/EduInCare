using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Entities;
using Foundation.Library.Contexts;
using Foundation.Library.Repositories;

namespace Foundation.Library.Repositories
{
    public class AdvertiseRepository : Repository<Advertise, Guid, WebsiteContext>, IAdvertiseRepository
    {
        public AdvertiseRepository(WebsiteContext context) : base(context)
        {
        }
    }
}