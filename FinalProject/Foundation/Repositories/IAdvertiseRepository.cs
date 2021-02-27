using System;
using DataAccessLayer;
using Foundation.Contexts;
using Foundation.Entities;

namespace Foundation.Repositories
{
    public interface IAdvertiseRepository : IRepository<Advertise, Guid, WebsiteContext>
    {
        
    }
}