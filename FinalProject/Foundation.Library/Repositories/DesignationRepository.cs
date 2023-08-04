using System;
using DataAccessLayer;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class DesignationRepository : Repository<Designation, Guid, WebsiteContext>, IDesignationRepository
    {
        public DesignationRepository(WebsiteContext context) : base(context)
        {
        }
    }
}