using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IDepartmentService
    {
        void AddDepartment(Department department);
        void DeleteDepartment(Guid id);
        Department GetDepartment(Guid id);
        (int total, int totalDisplay, IList<Department> records) GetDepartmentList(int pageIndex,
            int pageSize, string searchText, string orderBy);
        void UpdateDepartment(Department department);
    }
}