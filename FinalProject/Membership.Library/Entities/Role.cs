﻿using System;
using Microsoft.AspNetCore.Identity;

namespace Membership.Library.Entities
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
