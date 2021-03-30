using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class AcademicYearRepository : Repository<AcademicYear, Guid, WebsiteContext>, IAcademicYearRepository
    {
        public AcademicYearRepository(WebsiteContext context) : base(context)
        {
        }
    }
}