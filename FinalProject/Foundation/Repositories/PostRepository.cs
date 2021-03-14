using System;
using DataAccessLayer;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class PostRepository : Repository<Post, Guid, WebsiteContext>, IPostRepository
    {
        public PostRepository(WebsiteContext context) : base(context)
        {
        }
    }
}