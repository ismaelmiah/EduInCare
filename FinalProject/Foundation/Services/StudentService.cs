using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.Repositories;

namespace Foundation.Library.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void CreateStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public (int total, int totalDisplay, IList<Student> records) GetStudentList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<Student> data, int total, int totalDisplay) result = (null, 0, 0);

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _studentRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize, true);

            }
            else
            {
                result = _studentRepository.GetDynamic(x => x.FirstName == searchText,
                    orderBy, "", pageIndex, pageSize, true);
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
                    PresentAddress = x.PresentAddress,
                    PermanentAddress = x.PermanentAddress,
                    PhotoImage = x.PhotoImage,
                    Nationality = x.Nationality,
                    YearOfEnroll = x.YearOfEnroll,
                    EnrollCourse = x.EnrollCourse,
                    ParentsInfo = x.ParentsInfo
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }
    }
}