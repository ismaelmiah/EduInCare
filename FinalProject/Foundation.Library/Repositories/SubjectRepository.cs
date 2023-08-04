using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class SubjectRepository : Repository<Subject, Guid, WebsiteContext>, ISubjectRepository
    {
        public SubjectRepository(WebsiteContext context) : base(context)
        {
        }
    }
}