using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IStudentParentService
    {
        (int total, int totalDisplay, IList<StudentParents> records) GetStudentsParentsList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
    }
}