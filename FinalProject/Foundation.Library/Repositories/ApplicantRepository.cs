using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class ApplicantRepository : Repository<Applicants, Guid, WebsiteContext>, IApplicantRepository
    {
        public ApplicantRepository(WebsiteContext context) : base(context)
        {
        }
    }
}