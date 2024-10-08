using JAR.Core.Contracts;
using JAR.Core.Models.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JAR.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService _companyService)
        {
            companyService = _companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new CompanyRegisterModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(CompanyRegisterModel model)
        {
            if (await companyService.CompanyWithUICExists(model.UIC))
            {
                ModelState.AddModelError(nameof(model.UIC), "Already exists company with the same UIC");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await companyService.CreateCompanyAsync(model, User.Id());
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
