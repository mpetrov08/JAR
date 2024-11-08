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
        public async Task<IActionResult> Create()
        {
            if (await cvService.UserHasCV(User.Id()))
            {
                return RedirectToAction(nameof(Preview));
            }

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

            return RedirectToAction(nameof(Preview));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = User.Id();

            if (!await cvService.Exists(id))
            {
                return BadRequest();
            }

            if (!await cvService.UserHasCVWithId(id, userId))
            {
                return BadRequest();
            }

            var cv = await cvService.GetCVFormModelByUserId(userId);

            cv.DegreesJson = JsonConvert.SerializeObject(cv.Degrees);
            cv.ProfessionalExperiencesJson = JsonConvert.SerializeObject(cv.ProfessionalExperiences);

            return View(cv);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CVFormModel model, int id)
        {
            if (!await cvService.Exists(id))
            {
                return BadRequest();
            }

            if (!await cvService.UserHasCVWithId(id, User.Id()))
            {
                return BadRequest();
            }

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

            await cvService.EditCV(model, id);

            return RedirectToAction(nameof(Preview));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string userId = User.Id();

            if (!await cvService.Exists(id))
            {
                return BadRequest();
            }

            if (!await cvService.UserHasCVWithId(id, userId))
            {
                return BadRequest();
            }

            await cvService.DeleteCV(id);

            return RedirectToAction(nameof(JobOfferController.All), "JobOffer");
        }

        [HttpGet]
        public async Task<IActionResult> Preview(string userId = null)
        {
            if (userId == null)
            {
                userId = User.Id();
            }

            var cv = await cvService.GetCVViewModelByUserId(userId);

            if (cv == null)
            {
                return BadRequest();
            }

            return View(cv);
        }
    }
}
