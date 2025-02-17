﻿using JAR.Core.Contracts;
using JAR.Core.Hubs;
using JAR.Core.Models.Chat;
using JAR.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace JAR.Controllers
{
    [Route("Messages")]
    public class MessagesController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IHubContext<ChatHub> chatHub;

        public MessagesController(IMessageService _messageService,
            IHubContext<ChatHub> _chatHub)
        {
            messageService = _messageService;
            chatHub = _chatHub;
        }

        [HttpGet("Get/{Id}")]
        public async Task<ActionResult<Room>> Get(int id)
        {
            var messageViewModel = await messageService.GetByIdAsync(id);
            if (messageViewModel == null)
            {
                return NotFound();
            }
            return Ok(messageViewModel);
        }

        [HttpGet("Room/{roomName}")]
        public async Task<IActionResult> GetMessages(string roomName)
        {
            var messagesViewModel = await messageService.GetMessagesAsync(roomName);
            if (messagesViewModel == null)
            {
                return BadRequest();
            }
            return Ok(messagesViewModel);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create([FromQuery] string content, [FromQuery] string room)
        {
            var createdMessage = await messageService.CreateAsync(new MessageViewModel()
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
            var userId = User.Id();
            var result = await messageService.DeleteAsync(id, userId);

            if (!result)
            {
                return NotFound();
            }

            await chatHub.Clients.All.SendAsync("deleteMessage", id);
            return Ok();
        }
    }
}
