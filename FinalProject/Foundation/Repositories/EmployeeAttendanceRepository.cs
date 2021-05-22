using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class EmployeeAttendanceRepository : Repository<EmployeeAttendance, Guid, WebsiteContext>, IEmployeeAttendanceRepository
    {
        public EmployeeAttendanceRepository(WebsiteContext context) : base(context)
        {
        }
    }
}