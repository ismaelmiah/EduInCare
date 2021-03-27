using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class EmploymentHistoryRepository : Repository<EmploymentHistory, Guid, WebsiteContext> , IEmploymentHistoryRepository
    {
        public EmploymentHistoryRepository(WebsiteContext context) : base(context)
        {
        }
    }
}