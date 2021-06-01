using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IResultService
    {
        void AddResult(Result result);
        bool DeleteResult(Guid id);
        Result GetResult(Expression<Func<Result, bool>> filter);
        void EditResult(Result result);
        IList<Result> GetResults(Expression<Func<Result, bool>> filter, string includeParams);
        (int total, int totalDisplay, IList<Result> records) GetResultList(int pageIndex, int pageSize,
            string searchText, string orderBy, Guid academicYearId, Guid courseId, Guid sectionId, Guid examId);
    }
}
