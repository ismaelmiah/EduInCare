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
        Group GetGroup(Guid id);
        void Update(Group group);
    }

    public class GroupService : IGroupService
    {
        public void AddGroup(Group @group)
        {
            throw new System.NotImplementedException();
        }

        public (int total, int totalDisplay, IList<Group> records) GetGroupList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public Group GetGroup(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Group @group)
        {
            throw new System.NotImplementedException();
        }
    }
}