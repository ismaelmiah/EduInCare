using System;
using DataAccessLayer;
using Foundation.Contexts;
using Foundation.Entities;

namespace Foundation.Repositories
{
    public interface IHeaderRepository : IRepository<Header, Guid, WebsiteContext>
    {

    }
}