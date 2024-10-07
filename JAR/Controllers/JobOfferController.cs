using JAR.Core.Contracts;
using JAR.Core.Models.JobOffer;
using JAR.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JAR.Controllers
{
    [Authorize]
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;

        private readonly ILogger<JobOfferController> logger;

        public JobOfferController(ILogger<JobOfferController> _logger, IJobOfferService _jobOfferService)
        {
            jobOfferService = _jobOfferService;
            logger = _logger;
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
    }
}
