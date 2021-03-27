using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class GroupService : IGroupService
    {
        private readonly IManagementUnitOfWork _management;

        public GroupService(IManagementUnitOfWork management)
        {
            _management = management;
        }
        public void AddGroup(Group @group)
        {
            _management.GroupRepository.Add(group);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Group> records) GetGroupList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<Group> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.GroupRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize, false);

            }
            else
            {
                result = _management.GroupRepository.GetDynamic(x => x.Name == searchText,
                    orderBy, "", pageIndex, pageSize, false);
            }

            var data = (from x in result.data
                select new Group
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.GroupRepository.Remove(id);
            _management.Save();
        }

        public Group GetGroup(Guid id)
        {
            return _management.GroupRepository.GetById(id);
        }

        public void Update(Group @group)
        {
            _management.GroupRepository.Edit(group);
            _management.Save();
        }
    }
}