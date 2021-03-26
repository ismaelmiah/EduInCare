using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public interface IExamTitleService
    {
        void AddExamTitle(ExamTitle examTitle);
        (int total, int totalDisplay, IList<ExamTitle> records) GetExamTitleList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        IList<ExamTitle> ExamTitles();
        void Delete(Guid id);
        ExamTitle GetExamTitle(Guid id);
        void Update(ExamTitle examTitle);
    }
    public class ExamTitleService : IExamTitleService
    {
        private readonly IManagementUnitOfWork _management;

        public ExamTitleService(IManagementUnitOfWork management)
        {
            _management = management;
        }
        public void AddExamTitle(ExamTitle examTitle)
        {
            _management.ExamTitleRepository.Add(examTitle);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<ExamTitle> records) GetExamTitleList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<ExamTitle> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.ExamTitleRepository.GetDynamic(null,
                    orderBy, "EducationLevel", pageIndex, pageSize, false);

            }
            else
            {
                result = _management.ExamTitleRepository.GetDynamic(x => x.TitleName == searchText,
                    orderBy, "EducationLevel", pageIndex, pageSize, false);
            }

            var data = (from x in result.data
                select new ExamTitle
                {
                    Id = x.Id,
                    TitleName = x.TitleName,
                    EducationLevel = x.EducationLevel
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public IList<ExamTitle> ExamTitles()
        {
            return _management.ExamTitleRepository.GetAll();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ExamTitle GetExamTitle(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ExamTitle examTitle)
        {
            throw new NotImplementedException();
        }
    }
}
