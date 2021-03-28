using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public interface IEmploymentHistoryRepository : IRepository<EmploymentHistory, Guid, WebsiteContext>
    {
        
    }
}