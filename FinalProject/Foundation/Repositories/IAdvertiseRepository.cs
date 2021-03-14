using System;
using DataAccessLayer;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public interface IAdvertiseRepository : IRepository<Advertise, Guid, WebsiteContext>
    {
        
    }
}