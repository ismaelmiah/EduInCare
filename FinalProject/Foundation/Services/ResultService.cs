using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class ResultService : IResultService
    {
        private readonly IManagementUnitOfWork _management;

        public ResultService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddResult(Result result)
        {
            _management.ResultRepository.Add(result);
            _management.Save();
        }

        public void DeleteResult(Guid id)
        {
            _management.ResultRepository.Remove(id);
            _management.Save();
        }

        public void EditResult(Result result)
        {
            _management.ResultRepository.Edit(result);
            _management.Save();
        }

        public IList<Result> GetResults(Expression<Func<Result, bool>> filter, string includeParams)
        {
            return _management.ResultRepository.Get(filter, null, includeParams, false);
        }

        public Result GetResult(Expression<Func<Result, bool>> filter)
        {
            return _management.ResultRepository.Get(filter).FirstOrDefault();
        }

        public (int total, int totalDisplay, IList<Result> records) GetResultList(int pageIndex, int pageSize, string searchText, string orderBy, 
            Guid academicYearId, Guid courseId, Guid sectionId, Guid examId)
        {
            (IList<Result> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.ResultRepository.GetDynamic(x=>x.AcademicYearId == academicYearId && x.CourseId == courseId 
                        && x.SectionId == sectionId && x.ExamId == examId, orderBy, "Student", pageIndex, pageSize);

            }
            else
            {
                result = _management.ResultRepository.GetDynamic(x => x.AcademicYearId == academicYearId && x.CourseId == courseId
                        && x.SectionId == sectionId && x.ExamId == examId 
                        && x.Student.RollNo.ToString() == searchText, orderBy, "Student", pageIndex, pageSize);
            }

            var data = (from x in result.data
                        select new Result
                        {
                            Id = x.Id,
                            StudentId = x.StudentId,
                            CourseId = x.CourseId,
                            AcademicYearId = x.AcademicYearId,
                            ExamId = x.ExamId,
                            Grade = x.Grade,
                            Point = x.Point,
                            TotalMarks = x.TotalMarks
                        }).ToList();

            return (result.total, result.totalDisplay, data);
        }
    }
}