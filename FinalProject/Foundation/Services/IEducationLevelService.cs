using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public interface IEducationLevelService
    {
        void AddEducationLevel(EducationLevel educationLevel);
        (int total, int totalDisplay, IList<EducationLevel> records) GetEducationLevelList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
        EducationLevel GetEducationLevel(Guid id);
        void Update(EducationLevel educationLevel);
        IList<EducationLevel> GetEducationLevels();
    }
    public class EducationLevelService : IEducationLevelService
    {
        private readonly IManagementUnitOfWork _management;

        public EducationLevelService(IManagementUnitOfWork management)
        {
            _management = management;
        }
        public void AddEducationLevel(EducationLevel educationLevel)
        {
            _management.EducationLevelRepository.Add(educationLevel);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<EducationLevel> records) GetEducationLevelList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<EducationLevel> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.EducationLevelRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize, false);

            }
            else
            {
                result = _management.EducationLevelRepository.GetDynamic(x => x.EducationLevelName == searchText,
                    orderBy, "", pageIndex, pageSize, false);
            }

            var data = (from x in result.data
                select new EducationLevel
                {
                    Id = x.Id,
                    EducationLevelName = x.EducationLevelName,
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public EducationLevel GetEducationLevel(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(EducationLevel educationLevel)
        {
            throw new NotImplementedException();
        }

        public IList<EducationLevel> GetEducationLevels()
        {
            return _management.EducationLevelRepository.GetAll();
        }
    }
}
