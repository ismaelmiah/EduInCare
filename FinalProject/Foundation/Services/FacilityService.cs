using System;
using System.Collections.Generic;
using Foundation.Library.BaseServices;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public interface IFacilityService : IBaseService<Facility>
    {

    }

    public class FacilityService : IFacilityService
    {
        private readonly IWebsiteUnitOfWork _website;

        public FacilityService(IWebsiteUnitOfWork website)
        {
            _website = website;
        }

        public Facility Get(Guid id) => _website.FacilityRepository.GetById(id);

        public void Create(Facility entity)
        {
            _website.FacilityRepository.Add(entity);
            _website.Save();
        }

        public void Update(Facility entity)
        {
            _website.FacilityRepository.Edit(entity);
            _website.Save();
        }

        public void Delete(Guid id) => _website.FacilityRepository.Remove(id);

        public IList<Facility> GetList() => _website.FacilityRepository.GetAll();


        public (int total, int totalDisplay, IList<Facility> records) GetListForDataTable(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}