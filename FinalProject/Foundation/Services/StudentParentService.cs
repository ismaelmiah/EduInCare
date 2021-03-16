using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class StudentParentService : IStudentParentService
    {
        private readonly IManagementUnitOfWork _management;

        public StudentParentService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public (int total, int totalDisplay, IList<Parents> records) GetStudentsParentsList(int pageIndex,
            int pageSize, string searchText, string orderBy)
        {
            (IList<Parents> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.ParentsRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize, true);

            }
            else
            {
                result = _management.ParentsRepository.GetDynamic(x => x.FatherName == searchText,
                    orderBy, "", pageIndex, pageSize, true);
            }

            var data = (from x in result.data
                select new Parents()
                {
                    Id = x.Id,
                    FatherName = x.FatherName,
                    FatherMobileNo = x.FatherMobileNo,
                    FatherAnnualIncome = x.FatherAnnualIncome,
                    FatherOccupation = x.FatherOccupation,
                    MotherName = x.MotherName,
                    MotherMobileNo = x.MotherMobileNo,
                    MotherOccupation = x.MotherOccupation,
                    GuardianName = x.GuardianName,
                    GuardianMobileNo = x.GuardianMobileNo,

                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}