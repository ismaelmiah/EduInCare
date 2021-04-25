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
            var marks = new Mark()
            {
                AcademicYearId = registration.AcademicYearId,
                CourseId = registration.CourseId,
                SectionId = registration.SectionId,
                StudentId = registration.StudentId
            };
            _management.MarkRepository.Add(marks);

            var student = _management.StudentRepository.GetById(registration.StudentId);
            student.RollNo = registration.RollNo;
            _management.StudentRepository.Edit(student);

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
            var registration = _management.RegistrationStudentRepository.GetById(id);
            _management.RegistrationStudentRepository.Remove(id);
            var marks = _management.MarkRepository.Get(x=>x.StudentId == registration.StudentId).FirstOrDefault();
            _management.MarkRepository.Remove(marks);
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
            _management.Save();
        }
    }
}