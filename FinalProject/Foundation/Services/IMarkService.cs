using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IMarkService
    {
        void AddMark(Mark mark);
        void DeleteMark(Guid id);
        void UpdateMark(Mark mark);
        IList<Mark> GetMarks();
        Mark GetMark(Guid id);
        (int total, int totalDisplay, IList<Mark> records) GetMarkList(int pageIndex, int pageSize,
            string searchText, string orderBy);
    }
}