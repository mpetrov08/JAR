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
            if (await cvService.UserHasCVAsync(User.Id()))
            {
                return RedirectToAction(nameof(Preview));
            }

            var model = new CVFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CVFormModel model)
        {
            if (model.Image != null && model.Image.Length > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fileName = Path.GetFileNameWithoutExtension(model.Image.FileName) + "_" + Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }

                model.PhotoUrl = "/images/" + fileName;
            }
            else
            {
                ModelState.AddModelError(nameof(model.Image), "Image is required.");
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

            if (!await cvService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await cvService.UserHasCVWithIdAsync(id, userId))
            {
                return BadRequest();
            }

            var cv = await cvService.GetCVFormModelByUserIdAsync(userId); 

            return View(cv);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CVFormModel model, int id)
        {
            if (!await cvService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await cvService.UserHasCVWithIdAsync(id, User.Id()))
            {
                return BadRequest();
            }

            if (model.Image != null && model.Image.Length > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fileName = Path.GetFileNameWithoutExtension(model.Image.FileName) + "_" + Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }

                model.PhotoUrl = "/images/" + fileName;
            }
            else
            {
                if (string.IsNullOrEmpty(model.PhotoUrl))
                {
                    ModelState.AddModelError(nameof(model.Image), "Image is required.");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await cvService.EditCVAsync(model, id);

            return RedirectToAction(nameof(Preview));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string userId = User.Id();

            if (!await cvService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await cvService.UserHasCVWithIdAsync(id, userId))
            {
                return BadRequest();
            }

            await cvService.DeleteCVAsync(id);

            return RedirectToAction(nameof(JobOfferController.All), "JobOffer");
        }

        [HttpGet]
        public async Task<IActionResult> Preview(string userId = null)
        {
            if (userId == null)
            {
                userId = User.Id();
            }

            var cv = await cvService.GetCVViewModelByUserIdAsync(userId);

            if (cv == null)
            {
                return BadRequest();
            }

            return View(cv);
        }
    }
}
