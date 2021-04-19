using System;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace Foundation.Library.Services
{
    public class ExamRuleService : IExamRuleService
    {
        private readonly IManagementUnitOfWork _management;

        public ExamRuleService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddExamRule(ExamRules examRule)
        {
            _management.ExamRuleRepository.Add(examRule);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<ExamRules> records)
            GetExamRuleList(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            (IList<ExamRules> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.ExamRuleRepository.GetDynamic(null,
                    orderBy, "Subject,Grade", pageIndex, pageSize);

            }
            else
            {
                result = _management.ExamRuleRepository.GetDynamic(x => x.TotalExamMarks.ToString() == searchText,
                    orderBy, "Subject,Grade", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new ExamRules
                {
                    Id = x.Id,
                    Subject = x.Subject,
                    Grade = x.Grade,
                    MarksDistribution = x.MarksDistribution,
                    TotalExamMarks = x.TotalExamMarks,
                    PassMarks = x.PassMarks
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.ExamRuleRepository.Remove(id);
            _management.Save();
        }

        public ExamRules GetExamRule(Guid id) => _management.ExamRuleRepository.Get(x=>x.Id == id, null, "Subject,Grade,Course,Exam", false).FirstOrDefault();

        public void Update(ExamRules examRule)
        {
            _management.ExamRuleRepository.Edit(examRule);
            _management.Save();
        }

        public IList<ExamRules> GetExamRules() => _management.ExamRuleRepository.GetAll();

    }
}