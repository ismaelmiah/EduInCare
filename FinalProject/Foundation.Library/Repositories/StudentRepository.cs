using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class StudentRepository : Repository<Student, Guid, WebsiteContext>, IStudentRepository
    {
        public StudentRepository(WebsiteContext context) : base(context)
        {
        }
    }
}