using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class CourseService : ICourseService
    {
        private readonly IManagementUnitOfWork _management;

        public CourseService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddCourse(Course course)
        {
            _management.CourseRepository.Add(course);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Course> records) GetCourseList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<Course> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.CourseRepository.GetDynamic(null,
                    orderBy, "Sections,Subjects,Department,Registration", pageIndex, pageSize);

            }
            else
            {
                result = _management.CourseRepository.GetDynamic(x => x.Name == searchText,
                    orderBy, "Sections,Subjects,Department,Registration", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new Course
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Duration = x.Duration,
                    Status = x.Status,
                    Subjects = x.Subjects,
                    Sections = x.Sections,
                    HaveCompulsorySubject = x.HaveCompulsorySubject,
                    MaxCompulsorySubject = x.MaxCompulsorySubject,
                    Department = x.Department,
                    Registration = x.Registration,
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.CourseRepository.Remove(id);
            _management.Save();
        }

        public Course GetCourse(Guid id)
        {
            return _management.CourseRepository.GetById(id);
        }

        public IList<Course> GetCourses()
        {
            return _management.CourseRepository.GetAll();
        }
        

        public IList<Course> GetCourses(Guid yearId)
        {
            return _management.CourseRepository.Get(x=>x.AcademicYearId==yearId);
        }

        public void Update(Course course)
        {
            _management.CourseRepository.Edit(course);
        }
    }
}