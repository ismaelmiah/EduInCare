using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class EmployeeAttendanceService : IEmployeeAttendanceService
    {
        private readonly IManagementUnitOfWork _management;

        public EmployeeAttendanceService(IManagementUnitOfWork management)
        {
            _management = management;
        }
        public EmployeeAttendance Get(Guid id)
        {
            return _management.EmployeeAttendanceRepository.GetById(id);
        }

        public void Create(EmployeeAttendance entity)
        {
            _management.EmployeeAttendanceRepository.Add(entity);
            _management.Save();
        }

        public void Update(EmployeeAttendance entity)
        {
            _management.EmployeeAttendanceRepository.Edit(entity);
            _management.Save();
        }

        public void Delete(Guid id)
        {
            _management.EmployeeAttendanceRepository.Remove(id);
            _management.Save();
        }

        public IList<EmployeeAttendance> GetList()
        {
            return _management.EmployeeAttendanceRepository.GetAll();
        }

        public (int total, int totalDisplay, IList<EmployeeAttendance> records) GetListForDataTable(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<EmployeeAttendance> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.EmployeeAttendanceRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize);

            }
            else
            {
                result = _management.EmployeeAttendanceRepository.GetDynamic(x => x.AttendanceDate.ToShortDateString() == searchText,
                    orderBy, "", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new EmployeeAttendance
                {
                    Id = x.Id,
                    Employee = x.Employee,
                    AttendanceDate = x.AttendanceDate
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }
    }
}