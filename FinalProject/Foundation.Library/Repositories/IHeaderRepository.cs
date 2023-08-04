using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public interface IHeaderRepository : IRepository<Header, Guid, WebsiteContext>
    {

    }
}