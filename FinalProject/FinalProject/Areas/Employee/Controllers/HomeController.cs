using Microsoft.AspNetCore.Mvc;
using System;
using FinalProject.Web.Areas.Employee.Models;
using FinalProject.Web.Areas.Student.Models;
using Microsoft.AspNetCore.Authorization;
using Membership.Library.Constants;
using System.Threading.Tasks;
using Membership.Library.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            //_userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        [AllowAnonymous]
        public IActionResult Upsert(Guid? id)
        {
            var model = new EmployeeFormViewModel();
            if (id == null)
                return View(model);

            model = model.ModelBuilder.BuildEmployeeModel(id.GetValueOrDefault());
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Upsert(EmployeeFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == new Guid())
                {
                    //Create
                    await model.ModelBuilder.SaveEmployee(model);
                }
                else
                {
                    //Update
                    model.ModelBuilder.UpdateEmployee(model.Id, model);
                }
            }
            return RedirectToRoute(new { Area = "", controller = "Home", action = "Index" });
        }

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Delete(Guid id)
        {
            var model = new EmployeeFormViewModel();
            model.ModelBuilder.DeleteEmployee(id);
            return RedirectToRoute(new { Area = "Admin", controller = "Employee", action = "Employees" });
        }
        [Authorize(policy: "AdminPolicy")]
        public IActionResult EmployeeReport(Guid id)
        {
            return View();
        }
        [Authorize(Policy = "MemberPolicy")]
        public IActionResult Profile(Guid id)
        {
            var model = new EmployeeProfileView();
            model = model.ModelBuilder.BuildEmployeeProfile(id);
            if (model == null)
                return NotFound();

            var user = _httpContextAccessor.HttpContext.User;
            model.isAdmin = user.HasClaim(x => x.Type == MembershipClaims.AdminClaimType && x.Value == MembershipClaims.AdminClaimValue) ? true : false;
            return View(model);
        }
    }
}
