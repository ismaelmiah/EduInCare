using System;
using DataAccessLayer;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class EmployeeEducationRepository: Repository<EmployeeEducation, Guid, WebsiteContext>, IEmployeeEducationRepository
    {
        public EmployeeEducationRepository(WebsiteContext context) : base(context)
        {
        }
    }
}