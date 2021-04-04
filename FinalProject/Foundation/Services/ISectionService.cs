using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface ISectionService
    {
        void AddSection(Section section);

        (int total, int totalDisplay, IList<Section> records) GetSectionList(int pageIndex, int pageSize,
            string searchText, string orderBy);

        void Delete(Guid id);
        Section GetSection(Guid id);
        void Update(Section section);
        IList<Section> GetSections();
        IList<Section> GetSections(Guid courseId);
    }
}