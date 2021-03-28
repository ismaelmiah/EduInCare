using System;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class GroupModelBuilder
    {
        private readonly IGroupService _groupService;

        public GroupModelBuilder(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public GroupModelBuilder()
        {
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
        }

        public GroupModel BuildGroupModel(Guid id)
        {
            var exGroup = _groupService.GetGroup(id);
            return new GroupModel
            {
                Name = exGroup.Name
            };
        }

        public void SaveGroup(GroupModel model)
        {
            _groupService.AddGroup(new Group{Name = model.Name});
        }

        public void UpdateGroup(Guid modelId, GroupModel model)
        {
            var entity = _groupService.GetGroup(modelId);
            entity.Name = model.Name;
            _groupService.Update(entity);
        }

        public void DeleteGroup(Guid id)
        {
            _groupService.Delete(id);
        }
        public object GetGroups(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _groupService.GetGroupList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name"
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Name,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }
    }
}