using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class StudentService : IStudentService
    {

        private readonly IManagementUnitOfWork _management;

        public StudentService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddStudent(Student student)
        {
            _management.StudentRepository.Add(student);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Student> records) GetStudentList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<Student> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.StudentRepository.GetDynamic(null,
                    orderBy, "Image", pageIndex, pageSize, true);

            }
            else
            {
                result = _management.StudentRepository.GetDynamic(x => x.FirstName == searchText,
                    orderBy, "Image", pageIndex, pageSize, true);
            }

            var data = (from x in result.data
                select new Student
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Gender = x.Gender,
                    MobileNo = x.MobileNo,
                    DateOfBirth = x.DateOfBirth,
                    BirthCertificateNo = x.BirthCertificateNo,
                    NationalIdentificationNo = x.NationalIdentificationNo,
                    Image = x.Image,
                    Nationality = x.Nationality,
                    YearOfEnroll = x.YearOfEnroll,
                    Course = x.Course,
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.StudentRepository.Remove(id);
            _management.Save();
        }

        public Student GetStudent(Guid id)
        {
            return _management.StudentRepository.Get(x => x.Id == id, null,
                "Image,Address,Course,Parents", false).FirstOrDefault();
        }

        public void Update(Student student)
        {
            _management.StudentRepository.Edit(student);
            _management.Save();
        }
    }
}