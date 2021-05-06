using System;
using System.Collections.Generic;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class AboutContentService : IBaseService<AboutContent>
    {
        private readonly IWebsiteUnitOfWork _website;

        public AboutContentService(IWebsiteUnitOfWork website)
        {
            _website = website;
        }

        public AboutContent Get(Guid id) => _website.AboutContentRepository.GetById(id);

        public void Create(AboutContent entity)
        {
            _website.AboutContentRepository.Add(entity);
            _website.Save();
        }

        public void Update(AboutContent entity)
        {
            _website.AboutContentRepository.Edit(entity);
            _website.Save();
        }

        public void Delete(Guid id) => _website.AboutContentRepository.Remove(id);

        public IList<AboutContent> GetList() => _website.AboutContentRepository.GetAll();

        public (int total, int totalDisplay, IList<AboutContent> records) GetListForDataTable(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}