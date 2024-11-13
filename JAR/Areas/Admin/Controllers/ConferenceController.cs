using JAR.Core.Contracts;
using JAR.Core.Models.Conference;
using static JAR.Infrastructure.Constants.DataConstants;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace JAR.Areas.Admin.Controllers
{
    public class ConferenceController : AdminController
    {
        private readonly IConferenceService conferenceService;

        public ConferenceController(IConferenceService _conferenceService)
        {
            conferenceService = _conferenceService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ConferenceFormModel();
            return View();
        }

        [HttpPost]
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
    }
}
