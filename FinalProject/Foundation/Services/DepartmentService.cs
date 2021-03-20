using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IManagementUnitOfWork _management;

        public DepartmentService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddDepartment(Department department)
        {
            _management.DepartmentRepository.Add(department);
            _management.Save();
        }

        public void DeleteDepartment(Guid id)
        {
            _management.DepartmentRepository.Remove(id);
            _management.Save();
        }

        public Department GetDepartment(Guid id)
        {
            return _management.DepartmentRepository.GetById(id);
        }

        public (int total, int totalDisplay, IList<Department> records) GetDepartmentList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<Department> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.DepartmentRepository.GetDynamic(null,
                    orderBy, "Employees,Courses", pageIndex, pageSize, false);

            }
            else
            {
                result = _management.DepartmentRepository.GetDynamic(x => x.Name == searchText,
                    orderBy, "Employees,Courses", pageIndex, pageSize, false);
            }

            var data = (from x in result.data
                select new Department
                {
                    Id = x.Id,
                    Name = x.Name,
                    Employees = x.Employees,
                    Courses = x.Courses,
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void UpdateDepartment(Department department)
        {
            _management.DepartmentRepository.Edit(department);
            _management.Save();
        }

        public IList<Department> GetDepartments()
        {
            return _management.DepartmentRepository.GetAll();
        }
    }
}