using System;
using DataAccessLayer;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class EmployeeRepository : Repository<Employee, Guid, WebsiteContext>, IEmployeeRepository
    {
        public EmployeeRepository(WebsiteContext context) : base(context)
        {
        }
    }
}