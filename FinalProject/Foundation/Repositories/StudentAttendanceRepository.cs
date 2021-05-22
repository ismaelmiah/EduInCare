using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class StudentAttendanceRepository : Repository<StudentAttendance, Guid, WebsiteContext>, IStudentAttendanceRepository
    {
        public StudentAttendanceRepository(WebsiteContext context) : base(context)
        {
        }
    }
}