using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public interface IMarkRepository : IRepository<Mark, Guid, WebsiteContext>
    {

    }
}