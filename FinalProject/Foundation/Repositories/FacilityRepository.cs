using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class FacilityRepository : Repository<Facility, Guid, WebsiteContext>, IFacilityRepository
    {
        public FacilityRepository(WebsiteContext context) : base(context)
        {
        }
    }
}