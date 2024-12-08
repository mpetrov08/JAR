﻿using JAR.Core.Contracts;
using JAR.Core.Models.Conference;
using static JAR.Infrastructure.Constants.AdministratorConstants;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using static Dropbox.Api.Files.ListRevisionsMode;

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
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            var conferences = new List<ConferenceViewModel>();

            if (await lecturerService.IsLecturerAsync(userId))
            {
                conferences.AddRange(await conferenceService.AllByLecturerIdAsync(userId));
            }

            conferences.AddRange(await conferenceService.AllByUserIdAsync(userId));

            return View(conferences);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await conferenceService.ExistsAsync(id))
            {
                return BadRequest("This conference does not exists");
            }

            var conference = await conferenceService.GetConferenceDetailsViewModelByIdAsync(id);
            return View(conference);
        }


        [HttpGet]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Add()
        {
            var model = new ConferenceFormModel();
            model.Lecturers = await lecturerService.AllOptionsAsync();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Add(ConferenceFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Lecturers = await lecturerService.AllOptionsAsync();
                return View(model);
            }

            await conferenceService.CreateConferenceAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!User.IsInRole(AdminRole) &&
                !await lecturerService.HasLecturerConferenceAsync(User.Id(), id))
            {
                return BadRequest("You do not have permission to edit Conference");
            }

            if (!await conferenceService.ExistsAsync(id))
            {
                return BadRequest("Conference does not exists");
            }

            var model = await conferenceService.GetConferenceFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ConferenceFormModel model, int id)
        {
            if (!User.IsInRole(AdminRole) &&
                !await lecturerService.HasLecturerConferenceAsync(User.Id(), id))
            {
                return BadRequest("You do not have permission to edit Conference");
            }

            if (!await conferenceService.ExistsAsync(id))
            {
                return BadRequest("Conference does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.Lecturers = await lecturerService.AllOptionsAsync();
                return View(model);
            }

            await conferenceService.EditConferenceAsync(model, id);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!User.IsInRole(AdminRole) &&
                !await lecturerService.HasLecturerConferenceAsync(User.Id(), id))
            {
                return BadRequest("You do not have permission to edit Conference");
            }

            if (!await conferenceService.ExistsAsync(id))
            {
                return BadRequest("Conference does not exists");
            }

            var model = await conferenceService.GetConferenceDetailsViewModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ConferenceDetailsViewModel model)
        {
            if (!User.IsInRole(AdminRole) &&
                !await lecturerService.HasLecturerConferenceAsync(User.Id(), model.Id))
            {
                return BadRequest("You do not have permission to edit Conference");
            }

            if (!await conferenceService.ExistsAsync(model.Id))
            {
                return BadRequest("Conference does not exists");
            }

            await conferenceService.DeleteConferenceAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(int conferenceId)
        {
            string userId = User.Id();

            if (!await conferenceService.ExistsAsync(conferenceId))
            {
                return BadRequest("Conference does not exists");
            }

            if (await conferenceService.HasUserSignedUpAsync(conferenceId, userId))
            {
                return BadRequest("You already signed up for this conference");
            }

            if (await conferenceService.IsConferenceOverAsync(conferenceId, DateTime.Now))
            {
                return BadRequest("Conference is over");
            }

            if (await lecturerService.HasLecturerConferenceAsync(userId, conferenceId))
            {
                return BadRequest("You are the lecturer of the conference");
            }

            await conferenceService.SignUpAsync(conferenceId, userId);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Unregister(int conferenceId)
        {
            string userId = User.Id();

            if (!await conferenceService.ExistsAsync(conferenceId))
            {
                return BadRequest("Conference does not exists");
            }

            if (!await conferenceService.HasUserSignedUpAsync(conferenceId, userId))
            {
                return BadRequest("You have not signed up for this conference");
            }

            if (await conferenceService.IsConferenceOverAsync(conferenceId, DateTime.Now))
            {
                return BadRequest("Conference is over");
            }

            await conferenceService.UnregisterAsync(conferenceId, userId);

            return RedirectToAction(nameof(All));
        }
    }
}