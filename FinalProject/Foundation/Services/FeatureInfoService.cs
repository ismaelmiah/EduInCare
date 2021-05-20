using System;
using System.Collections.Generic;
using Foundation.Library.BaseServices;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class FeatureInfoService : IFeatureInfoService
    {
        private readonly IWebsiteUnitOfWork _website;

        public FeatureInfoService(IWebsiteUnitOfWork website)
        {
            _website = website;
        }

        public FeatureInfos Get(Guid id) => _website.FeatureInfoRepository.GetById(id);

        public void Create(FeatureInfos entity)
        {
            _website.FeatureInfoRepository.Add(entity);
            _website.Save();
        }

        public void Update(FeatureInfos entity)
        {
            _website.FeatureInfoRepository.Edit(entity);
            _website.Save();
        }

        public void Delete(Guid id) => _website.FeatureInfoRepository.Remove(id);

        public IList<FeatureInfos> GetList() => _website.FeatureInfoRepository.GetAll();


        public (int total, int totalDisplay, IList<FeatureInfos> records) GetListForDataTable(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            throw new NotImplementedException();
        }
    }

    public interface IFeatureInfoService : IBaseService<FeatureInfos>
    {

    }
}