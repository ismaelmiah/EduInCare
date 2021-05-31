using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Course.Models;
using FinalProject.Web.Areas.Employee.Models;
using FinalProject.Web.Models;
using Membership.Library.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(policy: "AdminPolicy")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ILogger<RegistrationModel> _logger;
        private readonly IEmailSender _emailSender;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ILogger<RegistrationModel> logger,
            IEmailSender emailSender,
            RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }
        //public async Task<IActionResult> Index()
        //{
        //    await _roleManager.CreateAsync(new Role { Name = "Admin" });
        //    await _roleManager.CreateAsync(new Role { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new Role { Name = "Teacher" });
        //    await _roleManager.CreateAsync(new Role { Name = "Student" });

        //    return RedirectToAction("Register");
        //}

        //public async Task<IActionResult> Register(string returnUrl = null)
        //{
        //    var model = new RegistrationModel
        //    {
        //        ReturnUrl = returnUrl,
        //        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
        //    };
        //    return View(model);
        //}
        //[HttpPost]
        public async Task<IActionResult> Register(string email, string username, string password, string phoneNumber, RoleType isEmployee)
        {
            //if (string.IsNullOrWhiteSpace(email) ||
            //    string.IsNullOrWhiteSpace(username) ||
            //    string.IsNullOrWhiteSpace(password))
            //    return RedirectToRoute(new {Area="", Controller="Account", Action="Error"});
            var user = new ApplicationUser { UserName = username, Email = email, PhoneNumber = phoneNumber, RoleType = isEmployee};
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                return RedirectToRoute(new { Area = "Admin", Controller = "Employee", Action = "Index" });
            }
            else
            {
                return RedirectToRoute(new { Area = "Admin", Controller = "Home", Action = "Index"});
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
