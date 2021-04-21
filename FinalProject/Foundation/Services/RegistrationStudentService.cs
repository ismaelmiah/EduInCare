using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class RegistrationStudentService : IRegistrationStudentService
    {
        private readonly IManagementUnitOfWork _management;

        public RegistrationStudentService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddRegistration(Registration registration)
        {
            _management.RegistrationStudentRepository.Add(registration);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Registration> records) GetRegistrationList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<Registration> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.RegistrationStudentRepository.GetDynamic(null,
                    orderBy, "AcademicYear,Course,Student,Section", pageIndex, pageSize);

            }
            else
            {
                result = _management.RegistrationStudentRepository.GetDynamic(x => x.CardNo == searchText,
                    orderBy, "AcademicYear,Course,Student,Section", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new Registration
                {
                    Id = x.Id,
                    Status = x.Status,
                    CardNo = x.CardNo,
                    AcademicYearId = x.AcademicYearId,
                    AcademicYear = x.AcademicYear,
                    Course = x.Course,
                    Section = x.Section,
                    Student = x.Student,
                    RegistrationNo = x.RegistrationNo,
                    BoardRegistrationNo = x.BoardRegistrationNo,
                    CourseId = x.CourseId,
                    IsPromoted = x.IsPromoted,
                    RollNo = x.RollNo,
                    OldRegistrationId = x.OldRegistrationId
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.RegistrationStudentRepository.Remove(id);
            _management.Save();
        }

        public Registration GetRegistration(Guid id)
        {
            return _management.RegistrationStudentRepository.GetById(id);
        }

        public IList<Registration> GetRegistrations()
        {
            return _management.RegistrationStudentRepository.GetAll();
        }

        public void Update(Registration registration)
        {
            _management.RegistrationStudentRepository.Edit(registration);
        }
    }
}