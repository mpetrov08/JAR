using JAR.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JAR.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [Route("User/All")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await userService.All();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> PromoteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            bool IsSucceeded = await userService.PromoteUserToAdminAsync(id);

            if (!IsSucceeded)
            {
                return BadRequest(); 
            }

            return RedirectToAction(nameof(All));   
        }

    }
}
