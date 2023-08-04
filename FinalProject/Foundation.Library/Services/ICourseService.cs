using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface ICourseService
    {
        void AddCourse(Course course);
        (int total, int totalDisplay, IList<Course> records) GetCourseList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        Course GetCourse(Guid id);
        void Delete(Guid id);
        IList<Course> GetCourses();
        IList<Course> GetCourses(Guid yearId);
        void Update(Course course);
    }
}