using JAR.Core.Contracts;
using JAR.Core.Models.Lecturer;
using Microsoft.AspNetCore.Mvc;

namespace JAR.Areas.Admin.Controllers
{
    public class LecturerController : AdminController
    {
        private readonly ILecturerService lecturerService;

        public LecturerController(ILecturerService _lecturerService)
        {
            lecturerService = _lecturerService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var lecturers = await lecturerService.AllAsync();
            return View(lecturers);
        }

        [HttpGet]
        public async Task<IActionResult> PromoteUserToLecturer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id is null");
            }

            var lecturer = new LecturerFormModel()
            {
                UserId = id
            };

            return View(lecturer);
        }

        [HttpPost]
        public async Task<IActionResult> PromoteUserToLecturer(LecturerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool isSucceeded = await lecturerService.PromoteToLecturer(model);

            if (!isSucceeded)
            {
                return BadRequest("Invalid data! Cannot promote user to lecturer.");
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> DemoteFromLecturer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id is null or empty");
            }

            var lecturerId = await lecturerService.GetLecturerId(id);
            bool isSucceeded = false;

            if (lecturerId > -1)
            {
                isSucceeded = await lecturerService.DemoteFromLecturerAsync(lecturerId);
            }
            else
            {
                isSucceeded = await lecturerService.DemoteFromLecturerAsync(int.Parse(id));
            }

            if (!isSucceeded)
            {
                return BadRequest("Id is invalid");
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await lecturerService.Exists(id))
            {
                return BadRequest("This lecturer does not exists");
            }

            var model =  await lecturerService.GetLecturerFormModel(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LecturerFormModel model, int id)
        {
            if (!await lecturerService.Exists(id))
            {
                return BadRequest("This lecturer does not exists");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await lecturerService.Edit(model, id);
            return RedirectToAction(nameof(All));
        }
    }
}