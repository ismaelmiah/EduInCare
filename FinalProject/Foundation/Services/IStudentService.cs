using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        (int total, int totalDisplay, IList<Student> records) GetStudentList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
    }
}