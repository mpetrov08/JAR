﻿using JAR.Core.Contracts;
using JAR.Core.Models.JobOffer;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Security.Claims;

namespace JAR.Controllers
{
    [Authorize]
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;

        private readonly ICompanyService companyService;

        private readonly ILogger<JobOfferController> logger;

        public JobOfferController(ILogger<JobOfferController> _logger, 
            IJobOfferService _jobOfferService, 
            ICompanyService _companyService)
        {
            jobOfferService = _jobOfferService;
            logger = _logger;
            companyService = _companyService;
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
            if (!await jobOfferService.Exists(id))
            {
                return BadRequest();
            }

            var jobOfferDetailsModel = await jobOfferService.JobOfferDetailsAsync(id);
            return View(jobOfferDetailsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new JobOfferAddModel()
            {
                Categories = await jobOfferService.AllCategories(),
                JobTypes = await jobOfferService.AllJobTypes(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(JobOfferAddModel model)
        {
            if (!await jobOfferService.CategoryExists(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!await jobOfferService.JobTypeExists(model.JobTypeId))
            {
                ModelState.AddModelError(nameof(model.JobTypeId), "Job Type does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await jobOfferService.AllCategories();

                return View(model);
            }

            int? companyId = await companyService.GetCompanyIdAsync(User.Id());
            int houseId = await jobOfferService.Create(model, companyId ?? 0, DateTime.Now);

            return RedirectToAction(nameof(Details), new { id = houseId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await jobOfferService.Exists(id))
            {
                return BadRequest();
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(id, User.Id()))
            {
                return Unauthorized();
            }

            var model = await jobOfferService.GetJobOfferAddModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, JobOfferAddModel model)
        {
            if(!await jobOfferService.Exists(id))
            {
                return BadRequest();
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(id, User.Id()))
            {
                return Unauthorized();
            }
            
            if (!await jobOfferService.CategoryExists(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!await jobOfferService.JobTypeExists(model.JobTypeId))
            {
                ModelState.AddModelError(nameof(model.JobTypeId), "Job Type does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await jobOfferService.AllCategories();
                model.JobTypes = await jobOfferService.AllJobTypes();
            }

            await jobOfferService.EditAsync(model, id);

            return RedirectToAction(nameof(Details), new { id });   
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await jobOfferService.Exists(id))
            {
                return BadRequest();
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(id, User.Id()))
            {
                return Unauthorized();
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
            if (!await jobOfferService.Exists(model.Id))
            {
                return BadRequest();
            }

            if (!await jobOfferService.HasCompanyWithIdAsync(model.Id, User.Id()))
            {
                return Unauthorized();
            }

            await jobOfferService.Delete(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
