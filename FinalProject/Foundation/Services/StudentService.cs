using System.Collections.Generic;
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

        public IList<Student> GetStudents()
        {
            return _studentRepository.GetAll();
        }
    }
}