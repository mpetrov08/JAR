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
            var companies = await companyService.GetAllCompanies();
            return View(companies);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveCompany(int id)
        {
            if (!await companyService.CompanyExists(id))
            {
                return BadRequest();
            }

            bool IsSucceeded = await companyService.ApproveCompany(id);

            if (!IsSucceeded)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
