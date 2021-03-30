using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IExamTitleService
    {
        void AddExamTitle(ExamTitle examTitle);
        (int total, int totalDisplay, IList<ExamTitle> records) GetExamTitleList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        IList<ExamTitle> ExamTitles();
        void Delete(Guid id);
        ExamTitle GetExamTitle(Guid id);
        void Update(ExamTitle examTitle);
    }
}
