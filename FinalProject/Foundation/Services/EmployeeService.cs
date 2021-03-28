using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IManagementUnitOfWork _management;
        public EmployeeService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public Employee GetEmployeeWithoutTrack(Guid id)
        {
            return _management.EmployeeRepository.Get(x => x.Id == id, null, "Image,Address,Department", false)
                .FirstOrDefault();
        }

        public Employee GetEmployee(Guid id)
        {
            return _management.EmployeeRepository.Get(x => x.Id == id, null, "Image,Address,Department", false)
                .FirstOrDefault();
        }

        public void DeleteEmployee(Guid id)
        {
            _management.EmployeeRepository.Remove(id);
            _management.Save();
        }

        public void UpdateEmployee(Employee employee)
        {
            _management.EmployeeRepository.Edit(employee);
            _management.Save();
        }

        public void AddEmployee(Employee employee)
        {
            _management.EmployeeRepository.Add(employee);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Employee> records) GetEmployeeList(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            (IList<Employee> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.EmployeeRepository.GetDynamic(null,
                    orderBy, "Section", pageIndex, pageSize, false);
            }
            else
            {
                result = _management.EmployeeRepository.GetDynamic(x => x.Name == searchText,
                    orderBy, "Section", pageIndex, pageSize, false);
            }

            var data = (from x in result.data
                        select new Employee
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Gender = x.Gender,
                            MobileNo = x.MobileNo,
                            Nid = x.Nid,
                            ImageUrl = x.ImageUrl,
                            UserName = x.UserName,
                            Nationality = x.Nationality,
                            JoinOfDate = x.JoinOfDate,
                        }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public IList<Employee> GetAllEmployees()
        {
            return _management.EmployeeRepository.GetAll();
        }
    }
}