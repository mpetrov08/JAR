using JAR.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JAR.Controllers
{
    public class ChatController : Controller
    {
        private readonly IRoomService roomService;

        public ChatController(IRoomService _roomService)
        {
            roomService = _roomService;
        }

        [Route("Chat")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await roomService.GetChatsViewModelAsync(User.Id());
            return View(model);
        }
    }
}
