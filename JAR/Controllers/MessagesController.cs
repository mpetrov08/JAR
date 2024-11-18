using JAR.Core.Contracts;
using JAR.Core.Models.Chat;
using JAR.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JAR.Controllers
{
    [Route("Messages")]
    public class MessagesController : Controller
    {
        private readonly IMessageService messageService;

        public MessagesController(IMessageService _messageService)
        {
            messageService = _messageService;
        }

        [HttpGet("Get/{Id}")]
        public async Task<ActionResult<Room>> Get(int id)
        {
            var messageViewModel = await messageService.GetById(id);
            if (messageViewModel == null)
            {
                return NotFound();
            }
            return Ok(messageViewModel);
        }

        [HttpGet("Room/{roomName}")]
        public async Task<IActionResult> GetMessages(string roomName)
        {
            var messagesViewModel = await messageService.GetMessages(roomName);
            if (messagesViewModel == null)
            {
                return BadRequest();
            }
            return Ok(messagesViewModel);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create([FromQuery] string content, [FromQuery] string room)
        {
            var createdMessage = await messageService.Create(new MessageViewModel()
            {
                Content = content,
                Room = room
            }, User.Id());
            if (createdMessage == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id = createdMessage.Id }, createdMessage);
        }

        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await messageService.Delete(id, User.Id());
            if (!res)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
