using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IDesignationService
    {
        void AddDesignation(Designation designation);
        (int total, int totalDisplay, IList<Designation> records) GetDesignationList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
        Designation GetDesignation(Guid id);
        void Update(Designation designation);
        IList<Designation> GetDesignations();
    }
}