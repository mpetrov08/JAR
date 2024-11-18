using JAR.Core.Models.User;
using JAR.Infrastructure.Data;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public readonly static List<UserChatModel> _Connections = new List<UserChatModel>();
        private readonly static Dictionary<string, string> _ConnectionsMap = new Dictionary<string, string>();
        private readonly IRepository repository;

        public ChatHub(IRepository _repository)
        {
            repository = _repository;
        }

        private string IdentityName
        {
            get
            {
                return Context.User.Identity.Name;
            }
        }

        public async Task Join(string roomName)
        {
            try
            {
                var user = _Connections.Where(u => u.UserName == IdentityName).FirstOrDefault();
                if (user != null && user.CurrentRoom != roomName)
                {
                    if (!string.IsNullOrEmpty(user.CurrentRoom))
                        await Clients.OthersInGroup(user.CurrentRoom).SendAsync("removeUser", user);

                    await Leave(user.CurrentRoom);
                    await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
                    user.CurrentRoom = roomName;

                    await Clients.OthersInGroup(roomName).SendAsync("addUser", user);
                }
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("onError", "You could not join the group!" + ex.Message);
            }
        }

        public async Task Leave(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public IEnumerable<UserChatModel> GetUsers(string roomName)
        {
            return _Connections.Where(u => u.CurrentRoom == roomName).ToList();
        }

        public override async Task OnConnectedAsync()
        {
            try
            {
                var user = await repository.AllReadOnly<User>().Where(u => u.UserName == IdentityName).FirstOrDefaultAsync();
                var userViewModel = new UserChatModel()
                {
                    FullName = user.FirstName + " " + user.LastName,
                    UserName = user.UserName
                };
                userViewModel.CurrentRoom = "";

                if (!_Connections.Any(u => u.UserName == IdentityName))
                {
                    _Connections.Add(userViewModel);
                    _ConnectionsMap.Add(IdentityName, Context.ConnectionId);
                }

                Clients.Caller.SendAsync("getProfileInfo", userViewModel);
            }
            catch (Exception ex)
            {
                Clients.Caller.SendAsync("onError", "OnConnected:" + ex.Message);
            }
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                var user = _Connections.Where(u => u.UserName == IdentityName).First();
                _Connections.Remove(user);

                Clients.OthersInGroup(user.CurrentRoom).SendAsync("removeUser", user);

                _ConnectionsMap.Remove(user.UserName);
            }
            catch (Exception ex)
            {
                Clients.Caller.SendAsync("onError", "OnDisconnected: " + ex.Message);
            }

            return base.OnDisconnectedAsync(exception);
        }
    }
}
