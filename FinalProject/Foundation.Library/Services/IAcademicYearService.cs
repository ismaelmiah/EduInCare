using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IAcademicYearService
    {
        void AddAcademicYear(AcademicYear academicYear);
        (int total, int totalDisplay, IList<AcademicYear> records) GetAcademicYearList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
        AcademicYear GetAcademicYear(Guid id);
        void Update(AcademicYear academicYear);
        IList<AcademicYear> GetAcademicYears();
    }
}