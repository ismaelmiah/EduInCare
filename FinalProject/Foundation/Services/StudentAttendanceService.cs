using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class StudentAttendanceService : IStudentAttendanceService
    {
        private readonly IManagementUnitOfWork _management;

        public StudentAttendanceService(IManagementUnitOfWork management)
        {
            _management = management;
        }
        public StudentAttendance Get(Guid id)
        {
            return _management.StudentAttendanceRepository.GetById(id);
        }

        public void Create(StudentAttendance entity)
        {
            _management.StudentAttendanceRepository.Add(entity);
            _management.Save();
        }

        public void Update(StudentAttendance entity)
        {
            _management.StudentAttendanceRepository.Edit(entity);
            _management.Save();
        }

        public void Delete(Guid id)
        {
            _management.StudentAttendanceRepository.Remove(id);
            _management.Save();
        }

        public IList<StudentAttendance> GetList()
        {
            return _management.StudentAttendanceRepository.GetAll();
        }

        public (int total, int totalDisplay, IList<StudentAttendance> records) GetListForDataTable(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<StudentAttendance> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.StudentAttendanceRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize);

            }
            else
            {
                result = _management.StudentAttendanceRepository.GetDynamic(x => x.AttendanceDate.ToShortDateString() == searchText,
                    orderBy, "", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new StudentAttendance
                {
                    Id = x.Id,
                    Student = x.Student,
                    IsPresent = x.IsPresent,
                    AttendanceDate = x.AttendanceDate
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public (int total, int totalDisplay, IList<StudentAttendance> records) GetListForDataTable(Guid courseId, int pageIndex, int pageSize,
            string searchText, string orderBy)
        {
            (IList<StudentAttendance> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.StudentAttendanceRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize);

            }
            else
            {
                result = _management.StudentAttendanceRepository.GetDynamic(x => x.CourseId == courseId,
                    orderBy, "", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new StudentAttendance
                {
                    Id = x.Id,
                    Student = x.Student,
                    IsPresent = x.IsPresent,
                    AttendanceDate = x.AttendanceDate
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }
    }
}