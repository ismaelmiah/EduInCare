using System;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Services;
using Membership.Library.Entities;

namespace FinalProject.Web.Areas.Administrative.Models.ModelBuilder
{
    public class RoleModelBuilder
    {
        private readonly IRoleService _roleService;

        public RoleModelBuilder(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public RoleModelBuilder()
        {
            _roleService = Startup.AutofacContainer.Resolve<IRoleService>();
        }
        public RoleModel BuildRoleModel(string id)
        {
            var xRole = _roleService.GetRole(id);
            return new RoleModel {Id = id, RoleName = xRole.Name};
        }

        public void SaveRole(RoleModel model)
        {
            _roleService.AddRole(new Role{Name = model.RoleName});
        }

        public void UpdateRole(string id, RoleModel model)
        {
            var xRole = _roleService.GetRole(id);
            xRole.Name = model.RoleName;
            _roleService.Update(xRole);
        }

        public object GetRoles(DataTablesAjaxRequestModel tableModel)
        {
            var getAllRoles = _roleService.GetRoles();

            return new
            {
                recordsTotal = getAllRoles.Count(),
                recordsFiltered = 10,
                data = (from record in getAllRoles
                        select new object[]
                        {
                            record.Name,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public void DeleteRole(string id)
        {
            _roleService.Delete(id);
        }
    }
}