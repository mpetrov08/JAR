using JAR.Core.Contracts;
using JAR.Core.Models.Lecturer;
using Microsoft.AspNetCore.Mvc;

namespace JAR.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;
        private readonly ILecturerService lecturerService;

        public UserController(IUserService _userService,
            ILecturerService _lecturerService)
        {
            userService = _userService;
            lecturerService = _lecturerService;
        }

        [Route("User/All")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await userService.AllAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> PromoteUserToAdmin(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id is null");
            }

            bool IsSucceeded = await userService.PromoteUserToAdminAsync(id);

            if (!IsSucceeded)
            {
                return BadRequest("Id is invalid"); 
            }

            return RedirectToAction(nameof(All));   
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdminRole(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id is null");
            }

            bool isSucceeded = await userService.RemoveAdminRoleAsync(id);

            if (!isSucceeded)
            {
                return BadRequest("Id is invalid");
            }

            return RedirectToAction(nameof(All));
        }
    }
}
