using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class ExamService : IExamService
    {
        private readonly IManagementUnitOfWork _management;

        public ExamService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddExam(Exam exam)
        {
            _management.ExamRepository.Add(exam);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Exam> records)
            GetExamList(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            (IList<Exam> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.ExamRepository.GetDynamic(null,
                    orderBy, "Course", pageIndex, pageSize);

            }
            else
            {
                result = _management.ExamRepository.GetDynamic(x => x.Name == searchText,
                    orderBy, "Course", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new Exam
                {
                    Id = x.Id,
                    Name = x.Name,
                    MarksDistributionTypes = x.MarksDistributionTypes,
                    Course = x.Course,
                    Status = x.Status,
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.ExamRepository.Remove(id);
            _management.Save();
        }

        public Exam GetExam(Guid id) => _management.ExamRepository.Get(x=>x.Id == id, null, "Course", false).FirstOrDefault();

        public void Update(Exam exam)
        {
            _management.ExamRepository.Edit(exam);
            _management.Save();
        }

        public IList<Exam> GetExams() => _management.ExamRepository.GetAll();
    }
}