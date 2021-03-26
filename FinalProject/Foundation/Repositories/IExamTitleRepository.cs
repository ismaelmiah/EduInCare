using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using Foundation.Library.Contexts;
using Foundation.Library.Entities;

namespace Foundation.Library.Repositories
{
    public interface IExamTitleRepository : IRepository<ExamTitle, Guid, WebsiteContext>
    {
    }
}
