using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class GradeService : IGradeService
    {
        private readonly IManagementUnitOfWork _management;

        public GradeService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddGrade(Grade grade)
        {
            _management.GradeRepository.Add(grade);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Grade> records) GetGradeList(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            (IList<Grade> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.GradeRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize);

            }
            else
            {
                result = _management.GradeRepository.GetDynamic(x => x.Name == searchText,
                    orderBy, "", pageIndex, pageSize);
            }

            var data = (from x in result.data
                        select new Grade
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Rule = x.Rule
                        }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.GradeRepository.Remove(id);
            _management.Save();
        }

        public Grade GetGrade(Guid id)
        {
            return _management.GradeRepository.GetById(id);
        }

        public void Update(Grade grade)
        {
            _management.GradeRepository.Edit(grade);
            _management.Save();
        }

        public IList<Grade> GetGrades()
        {
            return _management.GradeRepository.GetAll();
        }
    }
}