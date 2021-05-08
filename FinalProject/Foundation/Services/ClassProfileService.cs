using System;
using System.Collections.Generic;
using Foundation.Library.BaseServices;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public interface IClassProfileService : IBaseService<ClassProfiles>
    {

    }
    public class ClassProfileService : IClassProfileService
    {
        private readonly IWebsiteUnitOfWork _website;

        public ClassProfileService(IWebsiteUnitOfWork website)
        {
            _website = website;
        }

        public ClassProfiles Get(Guid id) => _website.ClassProfileRepository.GetById(id);

        public void Create(ClassProfiles entity)
        {
            _website.ClassProfileRepository.Add(entity);
            _website.Save();
        }

        public void Update(ClassProfiles entity)
        {
            _website.ClassProfileRepository.Edit(entity);
            _website.Save();
        }

        public void Delete(Guid id) => _website.ClassProfileRepository.Remove(id);

        public IList<ClassProfiles> GetList() => _website.ClassProfileRepository.GetAll();


        public (int total, int totalDisplay, IList<ClassProfiles> records) GetListForDataTable(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}