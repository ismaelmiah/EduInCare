using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IGroupService
    {
        void AddGroup(Group group);
        (int total, int totalDisplay, IList<Group> records) GetGroupList(int pageIndex, int pageSize, string searchText, string orderBy);
        void Delete(Guid id);
        IList<Group> GetGroups();
        Group GetGroup(Guid id);
        void Update(Group group);
    }
}