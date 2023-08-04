using System.Collections.Generic;
using Membership.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IRoleService
    {
        void AddRole(Role role);
        void Delete(string id);
        IList<Role> GetRoles();
        void Update(Role role);
        Role GetRole(string id);
    }
}