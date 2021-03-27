using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class CourseRepository : Repository<Course, Guid, WebsiteContext>, ICourseRepository
    {
        public CourseRepository(WebsiteContext context) : base(context)
        {
        }
    }
}