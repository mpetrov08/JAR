using JAR.Core.Contracts;
using JAR.Core.Models.Company;
using static JAR.Infrastructure.Constants.AdministratorConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
            if (await companyService.CompanyWithUICExistsAsync(model.UIC))
            {
                ModelState.AddModelError(nameof(model.UIC), "Already exists company with the same UIC");
            }


            if (model.Image != null && model.Image.Length > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fileName = Path.GetFileNameWithoutExtension(model.Image.FileName) + "_" + Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }

                model.LogoUrl = "/images/" + fileName;
            }
            else
            {
                ModelState.AddModelError(nameof(model.Image), "Invalid image");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await companyService.CreateCompanyAsync(model, User.Id());
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            string userId = User.Id();

            if (!await companyService.OwnerCompanyExistsAsync(userId))
            {
                return BadRequest();
            }
            
            var companyId = await companyService.GetCompanyIdAsync(userId);
            var company = await companyService.GetCompanyViewModelByIdAsync(companyId);

            if (company == null)
            {
                return BadRequest();
            }

            return View(company);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CompanyViewModel model)
        {
            string userId = User.Id();

            if (!await companyService.CompanyExistsAsync(model.Id))
            {
                return BadRequest();
            }

            if (!await companyService.OwnerCompanyExistsAsync(userId))
            {
                return BadRequest();
            }

            await companyService.DeleteAsync(model.Id);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> All()
        {
            var companies = await companyService.GetAllCompaniesAsync();
            return View(companies);
        }

        [HttpPost]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> ApproveCompany(int id)
        {
            if (!await companyService.CompanyExistsAsync(id))
            {
                return BadRequest();
            }

            bool IsSucceeded = await companyService.ApproveCompanyAsync(id);

            if (!IsSucceeded)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> DisapproveCompany(int id)
        {
            if (!await companyService.CompanyExistsAsync(id))
            {
                return BadRequest();
            }
            bool IsSucceeded = await companyService.DisapproveCompanyAsync(id);

            if (!IsSucceeded)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
