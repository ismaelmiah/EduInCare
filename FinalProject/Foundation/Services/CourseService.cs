﻿using System;
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
                    orderBy, "", pageIndex, pageSize, true);

            }
            else
            {
                result = _management.CourseRepository.GetDynamic(x => x.Title == searchText,
                    orderBy, "", pageIndex, pageSize, true);
            }

            var data = (from x in result.data
                select new Course
                {
                    Id = x.Id,
                    Title = x.Title

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
    }
}