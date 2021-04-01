using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IManagementUnitOfWork _management;

        public SubjectService(IManagementUnitOfWork management)
        {
            _management = management;
        }
        public void AddSubject(Subject subject)
        {
            _management.SubjectRepository.Add(subject);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Subject> records) GetSubjectList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<Subject> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.SubjectRepository.GetDynamic(null,
                    orderBy, "Course", pageIndex, pageSize, false);

            }
            else
            {
                result = _management.SubjectRepository.GetDynamic(x => x.Name == searchText,
                    orderBy, "Course", pageIndex, pageSize, false);
            }

            var data = (from x in result.data
                select new Subject
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Course = x.Course,
                    ExcludeInResult = x.ExcludeInResult
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.SubjectRepository.Remove(id);
            _management.Save();
        }

        public IList<Subject> GetSubjects()
        {
            return _management.SubjectRepository.GetAll();
        }

        public IList<Subject> GetSubjects(Guid courseId)
        {
            var subjects = _management.SubjectRepository.Get(x => x.CourseId == courseId);
            return subjects;
        }

        public Subject GetSubject(Guid id)
        {
            return _management.SubjectRepository.GetById(id);
        }

        public void Update(Subject subject)
        {
            _management.SubjectRepository.Edit(subject);
            _management.Save();
        }
    }
}