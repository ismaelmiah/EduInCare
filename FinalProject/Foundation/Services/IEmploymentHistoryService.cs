using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IEmploymentHistoryService
    {
        EmploymentHistory GetEmploymentHistoryWithoutTrack(Guid id);
        EmploymentHistory GetEmploymentHistory(Guid id);
        void Delete(Guid id);
        void Update(EmploymentHistory employmentHistory);
        void AddEmploymentHistory(EmploymentHistory employmentHistory);

        (int total, int totalDisplay, IList<EmploymentHistory> records) GetEmploymentHistoryList(int pageIndex, int pageSize, string searchText, string orderBy);

        IList<EmploymentHistory> GetAllEmploymentHistories();
    }
}