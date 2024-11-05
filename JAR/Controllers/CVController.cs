using JAR.Core.Contracts;
using JAR.Core.Models.CV;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            if (!string.IsNullOrEmpty(model.DegreesJson))
            {
                model.Degrees = JsonConvert.DeserializeObject<List<DegreeFormModel>>(model.DegreesJson);
            }

            if (!string.IsNullOrEmpty(model.ProfessionalExperiencesJson))
            {
                model.ProfessionalExperiences = JsonConvert.DeserializeObject<List<ProfessionalExperienceFormModel>>(model.ProfessionalExperiencesJson);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await cvService.CreateCVAsync(model, User.Id());

            return RedirectToAction(nameof(JobOfferController.All), "JobOffer");
        }

        [HttpGet]
        public async Task<IActionResult> Preview()
        {
            var cv = await cvService.GetCVByUserId(User.Id());

            if (cv == null)
            {
                return BadRequest();
            }

            return View(cv);
        }
    }
}
