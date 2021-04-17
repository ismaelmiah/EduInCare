using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class GradeRepository : Repository<Grade, Guid, WebsiteContext>, IGradeRepository
    {
        public GradeRepository(WebsiteContext context) : base(context)
        {
        }
    }
}