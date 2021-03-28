using System;
using DataAccessLayer;
using DataAccessLayer.Library;
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