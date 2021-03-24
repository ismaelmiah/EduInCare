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
    }
}
