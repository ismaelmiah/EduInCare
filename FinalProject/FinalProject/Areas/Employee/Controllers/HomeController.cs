using Microsoft.AspNetCore.Mvc;
using System;
using FinalProject.Web.Areas.Employee.Models;
using FinalProject.Web.Areas.Student.Models;
using Microsoft.AspNetCore.Authorization;
using Membership.Library.Constants;
using System.Threading.Tasks;

namespace FinalProject.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
            if(User.Identity.IsAuthenticated)
            {
                ViewBag.isAdmin = User.HasClaim(x => x.Type == MembershipClaims.AdminClaimType && x.Value == MembershipClaims.AdminClaimValue) ? true : false;

            }
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
            if (!ModelState.IsValid)
                return View(model);
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
            return RedirectToRoute(new { Area = "Admin", controller = "Employee", action = "Employees" });
        }

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Delete(Guid id)
        {
            var model = new EmployeeFormViewModel();
            model.ModelBuilder.DeleteEmployee(id);
            return RedirectToRoute(new { Area = "Admin", controller = "Employee", action = "Employees" });
        }
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
            return View(model);
        }
    }
}
