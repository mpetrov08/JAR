using JAR.Core.Contracts;
using JAR.Core.Models.JobApplication;
using JAR.Core.Models.JobOffer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JAR.Controllers
{
    [Authorize]
    public class JobApplicationController : Controller
    {
        private readonly IJobOfferService jobOfferService;
        private readonly IJobApplicationService jobApplicationService;
        private readonly ICompanyService companyService;

        public JobApplicationController(IJobOfferService _jobOfferService, 
            IJobApplicationService _jobApplicationService,
            ICompanyService _companyService)
        {
            jobOfferService = _jobOfferService;
            jobApplicationService = _jobApplicationService;
            companyService = _companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Apply(int id)
        {
            if (!await jobOfferService.Exists(id))
            {
                return BadRequest();
            }

            if (await jobApplicationService.HasUserAlreadyAppliedAsync(id, User.Id()))
            {
                return BadRequest();
            }

            if (await companyService.OwnerCompanyExistsAsync(User.Id()))
            {
                return BadRequest();
            }

            var jobOffer = await jobOfferService.JobOfferDetailsAsync(id);

            var model = new JobOfferDetailsViewModel()
            {
                Id = id,
                Title = jobOffer.Title,
                Description = jobOffer.Description,
                Address = jobOffer.Address,
                RequiredSkills = jobOffer.RequiredSkills,
                RequiredDegree = jobOffer.RequiredDegree,
                RequiredExperience = jobOffer.RequiredExperience,
                RequiredLanguage = jobOffer.RequiredLanguage,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Apply(JobOfferDetailsViewModel model)
        {
            if (!await jobOfferService.Exists(model.Id))
            {
                return BadRequest();
            }

            if (await jobApplicationService.HasUserAlreadyAppliedAsync(model.Id, User.Id()))
            {
                return BadRequest();
            }

            if (await companyService.OwnerCompanyExistsAsync(User.Id()))
            {
                return BadRequest();
            }

            await jobApplicationService.Apply(model.Id, User.Id(), DateTime.Now);

            return RedirectToAction(nameof(JobOfferController.All), "JobOffer");
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int jobId, string userId)
        {

            if (!await jobOfferService.Exists(jobId))
            {
                return BadRequest();
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(jobId, User.Id()))
            {
                return Unauthorized();
            }

            if (!await jobApplicationService.HasUserAlreadyAppliedAsync(jobId, userId))
            {
                return BadRequest();
            }

            await jobApplicationService.Approve(jobId, userId);
            return RedirectToAction(nameof(JobOfferController.ViewApplicants), "JobOffer", new { id = jobId });
        }

        [HttpGet]
        public async Task<IActionResult> CheckStatus(int jobId)
        {
            string userId = User.Id();

            if (!await jobOfferService.Exists(jobId))
            {
                return BadRequest();
            }

            if (!await jobApplicationService.HasUserAlreadyAppliedAsync(jobId, User.Id()))
            {
                return BadRequest();
            }

            var IsApproved = await jobApplicationService.CheckStatus(jobId, User.Id());
            var jobOffer = await jobOfferService.JobOfferDetailsAsync(jobId);
            var model = new JobApplicationStatusViewModel()
            {
                Title = jobOffer.Title,
                Description = jobOffer.Description,
                Address = jobOffer.Address,
                IsApproved = IsApproved,
            };

            return View(model);
        }
    }
}
