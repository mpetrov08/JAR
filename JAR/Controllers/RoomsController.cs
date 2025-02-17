﻿using JAR.Core.Contracts;
using JAR.Core.Enumerations;
using JAR.Core.Models.Chat;
using JAR.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JAR.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService roomService;

        public RoomsController(IRoomService _roomService)
        {
            roomService = _roomService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<RoomViewModel>>> Get()
        {
            var roomsViewModel = await roomService.GetAllAsync(User.Id());
            return Ok(roomsViewModel);
        }

        [HttpGet("Get/{Id}")]
        public async Task<ActionResult<Room>> Get(int id)
        {
            var roomViewModel = await roomService.GetByIdAsync(id, User.Id());
            if (roomViewModel == null)
            {
                return NotFound();
            }
            return Ok(roomViewModel);
        }

        [HttpGet("Create")]
        public async Task<ActionResult<Room>> Create(string name, string companyOwnerId)
        {
            RoomViewModel viewModel = new RoomViewModel()
            {
                Name = name
            };
            var createdRoom = await roomService.CreateAsync(viewModel, User.Id(), companyOwnerId);
            if (createdRoom == null)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(ChatController.Index), "Chat");
        }

        [HttpGet("Edit/{Id}")]
        public async Task<IActionResult> Edit(int id, string name)
        {
            var status = await roomService.EditAsync(id, new RoomViewModel()
            {
                Name = name
            }, User.Id());
            if (status == HttpError.NotFound)
            {
                return NotFound();
            }

            if (status == HttpError.BadRequest)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isOkay = await roomService.DeleteAsync(id, User.Id());
            if (!isOkay)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("Join/{Id}")]
        public async Task<IActionResult> Join(int id)
        {
            bool isOkay = await roomService.AddUserAsync(id, User.Id());
            if (!isOkay)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Chat");
        }
    }
}
