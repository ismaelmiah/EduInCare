using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IEmployeeEducationService
    {
        EmployeeEducation GetEmployeeEducationWithoutTrack(Guid id);
        EmployeeEducation GetEmployeeEducation(Guid id);
        void DeleteEmployeeEducation(Guid id);
        void UpdateEmployeeEducation(EmployeeEducation employee);
        void AddEmployeeEducation(EmployeeEducation employee);

        (int total, int totalDisplay, IList<EmployeeEducation> records) GetEmployeeEducationList(int pageIndex,
            int pageSize, string searchText, string orderBy);
    }
}