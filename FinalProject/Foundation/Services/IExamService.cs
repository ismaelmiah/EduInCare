using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IExamService
    {
        void AddExam(Exam exam);
        (int total, int totalDisplay, IList<Exam> records) GetExamList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
        Exam GetExam(Guid id);
        void Update(Exam exam);
        IList<Exam> GetExams();
        IList<Exam> GetExams(Guid courseId);
    }
}