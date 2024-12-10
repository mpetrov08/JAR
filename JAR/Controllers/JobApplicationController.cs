using JAR.Core.Contracts;
using JAR.Core.Models.JobApplication;
using JAR.Core.Models.JobOffer;
using JAR.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Dropbox.Api.Files.ListRevisionsMode;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            if (!await jobOfferService.ExistsAsync(id))
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
            if (!await jobOfferService.ExistsAsync(model.Id))
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

            await jobApplicationService.ApplyAsync(model.Id, User.Id(), DateTime.Now);

            return RedirectToAction(nameof(JobOfferController.All), "JobOffer");
        }

        [HttpPost]
        public async Task<IActionResult> WithdrawApplication(int jobId)
        {
            if (!await jobOfferService.ExistsAsync(jobId))
            {
                return BadRequest();
            }

            if (!await jobApplicationService.HasUserAlreadyAppliedAsync(jobId, User.Id()))
            {
                return BadRequest();
            }

            if (await companyService.OwnerCompanyExistsAsync(User.Id()))
            {
                return BadRequest();
            }

            await jobApplicationService.WithdrawApplicationAsync(jobId, User.Id());

            return RedirectToAction(nameof(JobOfferController.Mine), "JobOffer");
        }

        [HttpGet]
        public async Task<IActionResult> Approve(int jobId, string userId)
        {
            var companyId = await companyService.GetCompanyIdAsync(User.Id());

            if (!await companyService.CompanyExistsAsync(companyId))
            {
                return BadRequest();
            }

            if (!await companyService.IsApprovedAsync(companyId))
            {
                return BadRequest();
            }

            if (!await jobOfferService.ExistsAsync(jobId))
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

            var applicant = await jobApplicationService.GetApplicantByIdAsync(jobId, userId);

            var model = new JobApplicationApproveViewModel()
            {
                JobId = jobId,
                UserId = userId,
                Email = applicant.Email,
                IsApproved = applicant.IsApproved,
                AppliedOn = applicant.AppliedOn,
                Message = await jobApplicationService.GetApprovalMessageAsync(jobId, userId)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(JobApplicationApproveViewModel model)
        {
            var companyId = await companyService.GetCompanyIdAsync(User.Id());

            if (!await companyService.CompanyExistsAsync(companyId))
            {
                return BadRequest();
            }

            if (!await companyService.IsApprovedAsync(companyId))
            {
                return BadRequest();
            }

            if (!await jobOfferService.ExistsAsync(model.JobId))
            {
                return BadRequest();
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(model.JobId, User.Id()))
            {
                return Unauthorized();
            }

            if (!await jobApplicationService.HasUserAlreadyAppliedAsync(model.JobId, model.UserId))
            {
                return BadRequest();
            }

            await jobApplicationService.ApproveAsync(model.JobId, model.UserId, model.Message);
            return RedirectToAction(nameof(JobOfferController.ViewApplicants), "JobOffer", new { id = model.JobId });
        }

        [HttpPost]
        public async Task<IActionResult> DisapproveAsync(int jobId, string userId)
        {
            var companyId = await companyService.GetCompanyIdAsync(User.Id());

            if (!await companyService.CompanyExistsAsync(companyId))
            {
                return BadRequest();
            }

            if (!await companyService.IsApprovedAsync(companyId))
            {
                return BadRequest();
            }

            if (!await jobOfferService.ExistsAsync(jobId))
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

            if (!await jobApplicationService.IsUserAlreadyApprovedAsync(jobId, userId))
            {
                return BadRequest();
            }

            await jobApplicationService.DisapproveAsync(jobId, userId);
            return RedirectToAction(nameof(JobOfferController.ViewApplicants), "JobOffer", new { id = jobId });
        }

        [HttpGet]
        public async Task<IActionResult> CheckStatus(int jobId)
        {
            string userId = User.Id();

            if (!await jobOfferService.ExistsAsync(jobId))
            {
                return BadRequest();
            }

            if (!await jobApplicationService.HasUserAlreadyAppliedAsync(jobId, userId))
            {
                return BadRequest();
            }

            var model = await jobApplicationService.GetJobApplicationStatusViewModelAsync(jobId, userId);

            return View(model);
        }
    }
}
