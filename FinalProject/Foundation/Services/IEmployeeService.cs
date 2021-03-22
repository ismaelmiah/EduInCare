using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IEmployeeService
    {
        Employee GetEmployeeWithoutTrack(Guid id);
        Employee GetEmployee(Guid id);
        void DeleteEmployee(Guid id);
        void UpdateEmployee(Employee employee);
        void AddEmployee(Employee employee);

        (int total, int totalDisplay, IList<Employee> records) GetEmployeeList(int pageIndex, int pageSize, string searchText, string orderBy);

        IList<Employee> GetAllEmployees();

    }
}