using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IRegistrationStudentService
    {
        void AddRegistration(Registration registration);
        (int total, int totalDisplay, IList<Registration> records) GetRegistrationList(int pageIndex,
            int pageSize, string searchText, string orderBy);

        Registration GetRegistration(Guid id);
        void Delete(Guid id);
        IList<Registration> GetRegistrations();
        void Update(Registration registration);
    }
}