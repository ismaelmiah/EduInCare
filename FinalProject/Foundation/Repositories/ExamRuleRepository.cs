using System;
using DataAccessLayer.Library;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public class ExamRuleRepository : Repository<ExamRules, Guid, WebsiteContext>, IExamRuleRepository
    {
        public ExamRuleRepository(WebsiteContext context) : base(context)
        {
        }
    }
}