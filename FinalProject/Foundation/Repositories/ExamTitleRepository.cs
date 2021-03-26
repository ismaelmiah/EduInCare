using System;
using DataAccessLayer;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class ExamTitleRepository : Repository<ExamTitle, Guid, WebsiteContext>, IExamTitleRepository
    {
        public ExamTitleRepository(WebsiteContext context) : base(context)
        {
        }
    }
}