using Microsoft.AspNetCore.Authorization;

namespace Foundation.Library.Policy
{
    public class NameRequirement : IAuthorizationRequirement
    {
        public NameRequirement()
        {
        }
    }
}
