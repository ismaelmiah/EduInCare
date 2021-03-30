using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class RegistrationStudentRepository : Repository<Registration, Guid, WebsiteContext>, IRegistrationStudentRepository
    {
        public RegistrationStudentRepository(WebsiteContext context) : base(context)
        {
        }
    }
}