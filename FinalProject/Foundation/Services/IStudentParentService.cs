using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IStudentParentService
    {
        (int total, int totalDisplay, IList<Parents> records) GetStudentsParentsList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
        Parents GetParents(Guid id);
        void Update(Parents parents);
    }
}