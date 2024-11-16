using JAR.Core.Contracts;
using JAR.Core.Models.Conference;
using static JAR.Infrastructure.Constants.AdministratorConstants;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace JAR.Controllers
{
    [Authorize]
    public class ConferenceController : Controller
    {
        private readonly IConferenceService conferenceService;
        private readonly ILecturerService lecturerService;

        public ConferenceController(IConferenceService _conferenceService, 
            ILecturerService _lecturerService)
        {
            conferenceService = _conferenceService;
            lecturerService = _lecturerService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var conferences = await conferenceService.AllAsync();
            return View(conferences);
        }

        [HttpGet]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Add()
        {
            var model = new ConferenceFormModel();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Add(ConferenceFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await conferenceService.CreateConferenceAsync(model);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await conferenceService.ExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await conferenceService.GetConferenceFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Edit(ConferenceFormModel model, int id)
        {
            if (!await conferenceService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await conferenceService.EditConferenceAsync(model, id);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await conferenceService.ExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await conferenceService.GetConferenceViewModelByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Delete(ConferenceViewModel model)
        {
            if (!await conferenceService.ExistsAsync(model.Id))
            {
                return BadRequest();
            }

            await conferenceService.DeleteConferenceAsync(model.Id);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(int conferenceId)
        {
            string userId = User.Id();

            if (!await conferenceService.ExistsAsync(conferenceId))
            {
                return BadRequest();
            }

            if (await conferenceService.HasUserSignedUp(conferenceId, userId))
            {
                return BadRequest();
            }

            if (await conferenceService.IsConferenceOver(conferenceId, DateTime.Now))
            {
                return BadRequest();
            }

            if (await lecturerService.HasLecturerConference(userId, conferenceId))
            {
                return BadRequest();
            }

            await conferenceService.SignUp(conferenceId, userId);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Unregister(int conferenceId)
        {
            string userId = User.Id();

            if (!await conferenceService.ExistsAsync(conferenceId))
            {
                return BadRequest();
            }

            if (!await conferenceService.HasUserSignedUp(conferenceId, userId))
            {
                return BadRequest();
            }

            if (await conferenceService.IsConferenceOver(conferenceId, DateTime.Now))
            {
                return BadRequest();
            }

            await conferenceService.Unregister(conferenceId, userId);

            return RedirectToAction(nameof(All));
        }
    }
}