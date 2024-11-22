using JAR.Core.Contracts;
using JAR.Core.Models.JobOffer;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Security.Claims;
using static Dropbox.Api.Files.ListRevisionsMode;

namespace JAR.Controllers
{
    [Authorize]
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;

        private readonly ICompanyService companyService;

        private readonly IJobApplicationService jobApplicationService;

        private readonly ILogger<JobOfferController> logger;

        public JobOfferController(ILogger<JobOfferController> _logger, 
            IJobOfferService _jobOfferService, 
            ICompanyService _companyService,
            IJobApplicationService _jobApplicationService)
        {
            jobOfferService = _jobOfferService;
            logger = _logger;
            companyService = _companyService;
            jobApplicationService = _jobApplicationService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] JobOffersFilterModel model)
        {
            var jobOffers = await jobOfferService.AllAsync(model.Category, 
                model.JobType, 
                model.SearchTerm, 
                model.Sorting, 
                model.CurrentPage, 
                model.JobOffersPerPage);

            model.TotalJobOffersCount = jobOffers.TotalJobOfferCount;
            model.JobOffers = jobOffers.JobOffers;
            model.Categories = await jobOfferService.AllCategoriesNamesAsync();
            model.JobTypes = await jobOfferService.AllJobTypeNamesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            var jobOffers = new List<JobOfferViewModel>();
            if (await companyService.OwnerCompanyExistsAsync(userId))
            {
                jobOffers = await jobOfferService.AllByOwnerIdAsync(userId);
            }
            else
            {
                jobOffers = await jobOfferService.AllByUserIdAsync(userId);
            }

            return View(jobOffers);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await jobOfferService.ExistsAsync(id))
            {
                return BadRequest("Job Offers does not exists");
            }

            var jobOfferDetailsModel = await jobOfferService.JobOfferDetailsAsync(id);
            return View(jobOfferDetailsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var companyId = await companyService.GetCompanyIdAsync(User.Id());

            if (!await companyService.CompanyExistsAsync(companyId))
            {
                return BadRequest("Company does not exists");
            }

            if (!await companyService.IsApproved(companyId))
            {
                return Unauthorized("Company is not approved");
            }

            var model = new JobOfferFormModel()
            {
                Categories = await jobOfferService.AllCategoriesAsync(),
                JobTypes = await jobOfferService.AllJobTypesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(JobOfferFormModel model)
        {
            var companyId = await companyService.GetCompanyIdAsync(User.Id());

            if (!await companyService.CompanyExistsAsync(companyId))
            {
                return BadRequest("Company does not exists");
            }

            if (!await companyService.IsApproved(companyId))
            {
                return Unauthorized("Company is not approved");
            }

            if (!await jobOfferService.CategoryExistsAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!await jobOfferService.JobTypeExistsAsync(model.JobTypeId))
            {
                ModelState.AddModelError(nameof(model.JobTypeId), "Job Type does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await jobOfferService.AllCategoriesAsync();
                model.JobTypes = await jobOfferService.AllJobTypesAsync();

                return View(model);
            }

            int houseId = await jobOfferService.CreateAsync(model, companyId, DateTime.Now);

            return RedirectToAction(nameof(Details), new { id = houseId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var companyId = await companyService.GetCompanyIdAsync(User.Id());

            if (!await companyService.CompanyExistsAsync(companyId))
            {
                return BadRequest("Company does not exists");
            }

            if (!await companyService.IsApproved(companyId))
            {
                return Unauthorized("Company is not approved");
            }

            if (!await jobOfferService.ExistsAsync(id))
            {
                return BadRequest("Job offer does not exists");
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(id, User.Id()))
            {
                return Unauthorized("This company is not owner of the job offer");
            }

            var model = await jobOfferService.GetJobOfferFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, JobOfferFormModel model)
        {
            var companyId = await companyService.GetCompanyIdAsync(User.Id());

            if (!await companyService.CompanyExistsAsync(companyId))
            {
                return BadRequest("Company does not exists");
            }

            if (!await companyService.IsApproved(companyId))
            {
                return Unauthorized("Company is not approved");
            }

            if (!await jobOfferService.ExistsAsync(id))
            {
                return BadRequest("Job offer does not exists");
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(id, User.Id()))
            {
                return Unauthorized("This company is not owner of the job offer");
            }

            if (!await jobOfferService.CategoryExistsAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!await jobOfferService.JobTypeExistsAsync(model.JobTypeId))
            {
                ModelState.AddModelError(nameof(model.JobTypeId), "Job Type does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await jobOfferService.AllCategoriesAsync();
                model.JobTypes = await jobOfferService.AllJobTypesAsync();
            }

            await jobOfferService.EditAsync(model, id);

            return RedirectToAction(nameof(Details), new { id });   
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var companyId = await companyService.GetCompanyIdAsync(User.Id());

            if (!await companyService.CompanyExistsAsync(companyId))
            {
                return BadRequest("Company does not exists");
            }

            if (!await companyService.IsApproved(companyId))
            {
                return Unauthorized("Company is not approved");
            }

            if (!await jobOfferService.ExistsAsync(id))
            {
                return BadRequest("Job Offer does not exists");
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(id, User.Id()))
            {
                return Unauthorized("This company is not the owner of the job offer");
            }

            var jobOffer = await jobOfferService.JobOfferDetailsAsync(id);

            var model = new JobOfferDetailsViewModel()
            {
                Id = id,
                Title = jobOffer.Title,
                Description = jobOffer.Description,
                Address = jobOffer.Address
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobOfferDetailsViewModel model)
        {
            var companyId = await companyService.GetCompanyIdAsync(User.Id());

            if (!await companyService.CompanyExistsAsync(companyId))
            {
                return BadRequest("Company does not exists");
            }

            if (!await companyService.IsApproved(companyId))
            {
                return Unauthorized("Company is not approved");
            }

            if (!await jobOfferService.ExistsAsync(model.Id))
            {
                return BadRequest("Job Offer does not exists");
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(model.Id, User.Id()))
            {
                return Unauthorized("This company is not the owner of the job offer");
            }

            await jobOfferService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> ViewApplicants(int id)
        {
            var companyId = await companyService.GetCompanyIdAsync(User.Id());

            if (!await companyService.CompanyExistsAsync(companyId))
            {
                return BadRequest("Company does not exists");
            }

            if (!await companyService.IsApproved(companyId))
            {
                return Unauthorized("Company is not approved");
            }

            if (!await jobOfferService.ExistsAsync(id))
            {
                return BadRequest("Job Offer does not exists");
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(id, User.Id()))
            {
                return Unauthorized("This company is not the owner of the job offer");
            }

            var jobApplicants = await jobApplicationService.GetApplicantsAsync(id);

            return View(jobApplicants);
        }
    }
}
