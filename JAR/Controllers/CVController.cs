using JAR.Core.Contracts;
using JAR.Core.Models.CV;
using JAR.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JAR.Controllers
{
    [Authorize]
    public class CVController : Controller
    {
        private readonly ICVService cvService;

        public CVController(ICVService _cvService)
        {
            cvService = _cvService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CVFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CVFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await cvService.CreateCV(model, User.Id());

            return RedirectToAction(nameof(JobOfferController.All), "JobOffer");
        }
    }
}
