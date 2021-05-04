using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class ResultRepository : Repository<Result, Guid, WebsiteContext>, IResultRepository
    {
        public ResultRepository(WebsiteContext context) : base(context)
        {
        }
    }
}