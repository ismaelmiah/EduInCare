using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IGradeService
    {
        void AddGrade(Grade grade);
        (int total, int totalDisplay, IList<Grade> records) GetGradeList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
        Grade GetGrade(Guid id);
        void Update(Grade grade);
        IList<Grade> GetGrades();
    }
}