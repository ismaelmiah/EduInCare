using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class EmploymentHistoryService : IEmploymentHistoryService
    {
        private readonly IManagementUnitOfWork _management;

        public EmploymentHistoryService(IManagementUnitOfWork management)
        {
            _management = management;
        }
        public EmploymentHistory GetEmploymentHistoryWithoutTrack(Guid id)
        {
            return _management.EmploymentHistoryRepository
                .Get(x=>x.Id==id, null,"",false).FirstOrDefault();
        }

        public EmploymentHistory GetEmploymentHistory(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(EmploymentHistory employmentHistory)
        {
            throw new NotImplementedException();
        }

        public void AddEmploymentHistory(EmploymentHistory employmentHistory)
        {
            _management.EmploymentHistoryRepository.Add(employmentHistory);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<EmploymentHistory> records) GetEmploymentHistoryList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<EmploymentHistory> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.EmploymentHistoryRepository.GetDynamic(null,
                    orderBy, "Designation,Employee", pageIndex, pageSize, false);
            }
            else
            {
                result = _management.EmploymentHistoryRepository.GetDynamic(x => x.Designation == searchText,
                    orderBy, "Designation,Employee", pageIndex, pageSize, false);
            }

            var data = (from x in result.data
                select new EmploymentHistory
                {
                    Id = x.Id,
                    Designation = x.Designation,
                    CompanyLocation = x.CompanyLocation,
                    CompanyName = x.CompanyName,
                    Employee = x.Employee,
                    From = x.From,
                    EmployeeId = x.EmployeeId,
                    To = x.To
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public IList<EmploymentHistory> GetAllEmploymentHistories()
        {
            return _management.EmploymentHistoryRepository.GetAll();
        }
    }
}