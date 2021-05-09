using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class TestimonialRepository : Repository<Testimonials, Guid, WebsiteContext>, ITestimonialRepository
    {
        public TestimonialRepository(WebsiteContext context) : base(context)
        {
        }
    }
}