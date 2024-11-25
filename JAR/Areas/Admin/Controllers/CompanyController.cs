using JAR.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JAR.Areas.Admin.Controllers
{
    public class CompanyController : AdminController
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService _companyService)
        {
            companyService = _companyService;
        }

        [Route("Company/All")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var companies = await companyService.GetAllCompaniesAsync();
            return View(companies);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveCompany(int id)
        {
            if (!await companyService.CompanyExistsAsync(id))
            {
                return BadRequest("Company does not exists");
            }

            bool IsSucceeded = await companyService.ApproveCompanyAsync(id);

            if (!IsSucceeded)
            {
                return BadRequest("Cannot approve company");
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> DisapproveCompany(int id)
        {
            if (!await companyService.CompanyExistsAsync(id))
            {
                return BadRequest("Company does not exists");
            }
            bool IsSucceeded = await companyService.DisapproveCompanyAsync(id);

            if (!IsSucceeded)
            {
                return BadRequest("Cannot approve company");
            }

            return RedirectToAction(nameof(All));
        }
    }
}