using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Membership.Library.Constants;
using Membership.Library.Contexts;
using Membership.Library.Entities;
using Membership.Library.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Membership.Library.Seed
{
    public static class InternalUserSeed
    {
        ////private readonly IUserManagerAdapter<ApplicationUser> _userManager;

        //private readonly UserManager _userManager;
        //public InternalUserSeed(UserManager userManager)
        //{
        //    _userManager = userManager;
        //    _adminUser = new ApplicationUser("ismail@gmail.com");
        //}
        
        public static async Task SeedInternalUserAsync(UserManager<ApplicationUser> _userManager)
        {
            IdentityResult result = null;
            var password = "admin@eduincare";
            var _adminUser = new ApplicationUser("ismail@gmail.com");
            if (await _userManager.FindByEmailAsync(_adminUser.UserName) == null)
            {
                result = await _userManager.CreateAsync(_adminUser, password);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimsAsync(
                        _adminUser,
                        new List<Claim>
                        {
                            new Claim(MembershipClaims.AdminClaimType, MembershipClaims.AdminClaimValue),
                            new Claim(MembershipClaims.MemberClaimType, MembershipClaims.MemberClaimValue)
                        });
                }
            }
        }
    }
}