using System.Collections.Generic;
using System.Linq;
using Membership.Library.Entities;
using Microsoft.AspNetCore.Identity;

namespace Foundation.Library.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public void AddRole(Role role)
        {
            _roleManager.CreateAsync(role);
        }

        public void Delete(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            _roleManager.DeleteAsync(role);
        }

        public IList<Role> GetRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public void Update(Role role)
        {
            _roleManager.UpdateAsync(role);
        }

        public Role GetRole(string id)
        {
            return _roleManager.FindByIdAsync(id).Result;
        }
    }
}