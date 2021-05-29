using System;
using DataAccessLayer.Library;
using Microsoft.AspNetCore.Identity;

namespace Membership.Library.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
                    : base()
        {

        }

        public ApplicationUser(string userName)
            : base(userName)
        {

        }

        public virtual RoleType RoleType { get; set; }
    }
    public enum RoleType
    {
        Teacher = 1,
        Employee = 2
    }
}
