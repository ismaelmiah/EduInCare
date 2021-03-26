using System;
using Microsoft.AspNetCore.Identity;

namespace Foundation.Library.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role()
        :base()
        {
        }

        public Role(string roleName)
            : base(roleName)
        {
        }
    }
}
