using System;
using Microsoft.AspNetCore.Identity;

namespace Membership.Library.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
                    : base()
        {

        }

        internal ApplicationUser(string userName)
            : base(userName)
        {

        }

        public virtual RoleType RoleType { get; set; }
    }
    public enum RoleType
    {
        Teacher = 1,
        Employee = 2,
        Student = 3
    }
}
