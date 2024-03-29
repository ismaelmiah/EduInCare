﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        (int total, int totalDisplay, IList<Student> records) GetStudentList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
        Student GetStudent(Guid id);
        void Update(Student student);
        IList<Student> GetStudents(Expression<Func<Student, bool>> filter);
    }
}