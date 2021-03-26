using System;
using DataAccessLayer;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class DepartmentRepository : Repository<Department, Guid, WebsiteContext>, IDepartmentRepository
    {
        public DepartmentRepository(WebsiteContext context) : base(context)
        {
        }
    }
}