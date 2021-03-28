using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class SectionService : ISectionService
    {
        private readonly IManagementUnitOfWork _management;

        public SectionService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddSection(Section section)
        {
            _management.SectionRepository.Add(section);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Section> records) GetSectionList(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            (IList<Section> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.SectionRepository.GetDynamic(null,
                    orderBy, "Course,Employee", pageIndex, pageSize, false);

            }
            else
            {
                result = _management.SectionRepository.GetDynamic(x => x.Name == searchText,
                    orderBy, "Course,Employee", pageIndex, pageSize, false);
            }

            var data = (from x in result.data
                        select new Section
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Course = x.Course,
                            Status = x.Status,
                            Employee = x.Employee,
                            TeacherId = x.TeacherId,
                            Capacity = x.Capacity,
                            CourseId = x.CourseId
                        }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.SectionRepository.Remove(id);
            _management.Save();
        }

        public Section GetSection(Guid id)
        {
            return _management.SectionRepository.GetById(id);
        }

        public IList<Section> GetSections()
        {
            return _management.SectionRepository.Get(null, null, "Course,Employee", false);
        }

        public void Update(Section section)
        {
            _management.SectionRepository.Edit(section);
        }
    }
}