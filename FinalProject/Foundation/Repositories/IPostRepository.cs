using System;
using DataAccessLayer;
using Foundation.Contexts;
using Foundation.Entities;

namespace Foundation.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid, WebsiteContext>
    {

    }
}