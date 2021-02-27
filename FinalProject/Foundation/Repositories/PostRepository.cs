using System;
using DataAccessLayer;
using Foundation.Contexts;
using Foundation.Entities;

namespace Foundation.Repositories
{
    public class PostRepository : Repository<Post, Guid, WebsiteContext>, IPostRepository
    {
        public PostRepository(WebsiteContext context) : base(context)
        {
        }
    }
}