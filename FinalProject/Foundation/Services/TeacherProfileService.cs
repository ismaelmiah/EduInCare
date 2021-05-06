using System;
using System.Collections.Generic;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class TeacherProfileService : IBaseService<TeacherProfiles>
    {
        private readonly IWebsiteUnitOfWork _website;

        public TeacherProfileService(IWebsiteUnitOfWork website)
        {
            _website = website;
        }

        public TeacherProfiles Get(Guid id) => _website.TeacherProfileRepository.GetById(id);

        public void Create(TeacherProfiles entity)
        {
            _website.TeacherProfileRepository.Add(entity);
            _website.Save();
        }

        public void Update(TeacherProfiles entity)
        {
            _website.TeacherProfileRepository.Edit(entity);
            _website.Save();
        }

        public void Delete(Guid id) => _website.TeacherProfileRepository.Remove(id);

        public IList<TeacherProfiles> GetList() => _website.TeacherProfileRepository.GetAll();

        public (int total, int totalDisplay, IList<TeacherProfiles> records) GetListForDataTable(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}