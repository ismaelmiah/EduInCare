using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class ExamRepository : Repository<Exam, Guid, WebsiteContext>, IExamRepository
    {
        public ExamRepository(WebsiteContext context) : base(context)
        {
        }
    }
}