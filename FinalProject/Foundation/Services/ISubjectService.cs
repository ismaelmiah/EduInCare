using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface ISubjectService
    {
        void AddSubject(Subject subject);
        (int total, int totalDisplay, IList<Subject> records) GetSubjectList(int pageIndex, int pageSize, string searchText, string orderBy);
        void Delete(Guid id);
        IList<Subject> GetSubjects();
        Subject GetSubject(Guid id);
        void Update(Subject subject);
    }
}