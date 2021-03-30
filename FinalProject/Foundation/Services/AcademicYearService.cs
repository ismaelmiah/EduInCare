using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class AcademicYearService : IAcademicYearService
    {
        private readonly IManagementUnitOfWork _management;

        public AcademicYearService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddAcademicYear(AcademicYear academicYear)
        {
            _management.AcademicYearRepository.Add(academicYear);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<AcademicYear> records) GetAcademicYearList(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            (IList<AcademicYear> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.AcademicYearRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize);

            }
            else
            {
                result = _management.AcademicYearRepository.GetDynamic(x => x.Title == searchText,
                    orderBy, "", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new AcademicYear
                {
                    Id = x.Id,
                    Title = x.Title,
                    EndDate = x.EndDate,
                    IsOpenForAdmission = x.IsOpenForAdmission,
                    Status = x.Status,
                    StartDate = x.StartDate
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.AcademicYearRepository.Remove(id);
            _management.Save();
        }

        public AcademicYear GetAcademicYear(Guid id)
        {
            return _management.AcademicYearRepository.GetById(id);
        }

        public void Update(AcademicYear academicYear)
        {
            _management.AcademicYearRepository.Edit(academicYear);
            _management.Save();
        }

        public IList<AcademicYear> GetAcademicYears()
        {
            return _management.AcademicYearRepository.GetAll();
        }
    }
}