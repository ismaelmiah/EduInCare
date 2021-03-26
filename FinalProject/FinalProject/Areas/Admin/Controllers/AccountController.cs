using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FinalProject.Web.Areas.Admin.Models;
using FinalProject.Web.Areas.Employee.Models;
using Foundation.Library.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace FinalProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public async Task<IActionResult> Register(string email, string username, string password, string phoneNumber)
        {
            //if (string.IsNullOrWhiteSpace(email) ||
            //    string.IsNullOrWhiteSpace(username) ||
            //    string.IsNullOrWhiteSpace(password))
            //    return RedirectToRoute(new {Area="", Controller="Account", Action="Error"});
            var user = new ApplicationUser { UserName = username, Email = email, PhoneNumber = phoneNumber};
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                return RedirectToRoute(new { Area = "", Controller = "Home", Action = "Index" });
            }
            else
            {
                return RedirectToRoute(new { Area = "Admin", Controller = "Home", Action = "Index"});
            }
        }

        public async Task<IActionResult> Login(string returnUrl = null)
        {
            var model = new LoginModel();
            if (!string.IsNullOrEmpty(model.ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, model.ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            model.ReturnUrl = returnUrl;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid) return View();
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                return LocalRedirect(returnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
