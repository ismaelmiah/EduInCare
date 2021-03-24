using Microsoft.AspNetCore.Authorization;

namespace Membership.Library.Policy
{
    public class NameRequirement : IAuthorizationRequirement
    {
        public NameRequirement()
        {
        }
    }
}
