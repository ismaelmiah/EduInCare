using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
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
                    //EducationLevel = x.EducationLevel
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public IList<ExamTitle> ExamTitles()
        {
            return _management.ExamTitleRepository.GetAll();
        }

        public void Delete(Guid id)
        {
            _management.ExamTitleRepository.Remove(id);
        }

        public ExamTitle GetExamTitle(Guid id)
        {
            return _management.ExamTitleRepository.GetById(id);
        }

        public void Update(ExamTitle examTitle)
        {
            _management.ExamTitleRepository.Edit(examTitle);
        }
    }
}