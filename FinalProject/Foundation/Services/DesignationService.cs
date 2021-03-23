using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly IManagementUnitOfWork _management;

        public DesignationService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddDesignation(Designation designation)
        {
            _management.DesignationRepository.Add(designation);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Designation> records) GetDesignationList(int pageIndex, int pageSize, string searchText, string orderBy)
        {

            (IList<Designation> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.DesignationRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize, false);

            }
            else
            {
                result = _management.DesignationRepository.GetDynamic(x => x.Name == searchText,
                    orderBy, "", pageIndex, pageSize, false);
            }

            var data = (from x in result.data
                select new Designation
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Designation GetDesignation(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Designation designation)
        {
            throw new NotImplementedException();
        }

        public IList<Designation> GetDesignations()
        {
            return _management.DesignationRepository.GetAll();
        }
    }
}