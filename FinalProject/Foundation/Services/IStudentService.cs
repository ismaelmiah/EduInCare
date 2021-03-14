using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IStudentService
    {
        void CreateStudent(Student student);
        IList<Student> GetStudents();
    }
}