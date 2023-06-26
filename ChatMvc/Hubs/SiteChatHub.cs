using Application.Account;
using Application.ChatRoom;
using Application.Message;
using Common.Utilities;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Drawing;

namespace Hubs
{
    public class SiteChatHub : Hub
    {
        #region Constructor
        private readonly IChatRoomService _chatRoomService;
        private readonly IMessageService _messageService;
        private readonly IAccountService _accountService;
        private readonly IHubContext<SupportHub> _supportHub;

        public SiteChatHub(IChatRoomService chatRoomService, IMessageService messageService, IAccountService accountService, IHubContext<SupportHub> supportHub)
        {
            _chatRoomService = chatRoomService;
            _messageService = messageService;
            _accountService = accountService;
            _supportHub = supportHub;


        }
        #endregion
        #region OnConnected And Disconnected
        public override async Task OnConnectedAsync()
        {
         
            var adminClients = await _chatRoomService.GetAdminClients();
            await Clients.Caller.SendAsync("GetAdminClients", adminClients);

            #region Update UserConnectionId
            var user = await _accountService.GetUserByuserName(Context.User.Identity.Name);
            await _chatRoomService.UpdateIsOnlineUser(user);
            var adminIds =await _chatRoomService.GetAdminUsersByUserId(user.Id);
            await _supportHub.Clients.Users(adminIds).SendAsync("UserConnected", user.Id);

            var userConnectionId = user.ConnectionId ?? "";
            var newUserConnectionId = Context.ConnectionId;
            string _currentUserConnectionId = userConnectionId;
            if (newUserConnectionId != userConnectionId)
            {
                _currentUserConnectionId = newUserConnectionId;
                await _chatRoomService.UpdateConnectionId(user, _currentUserConnectionId);
            }
            #endregion
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var user = await _accountService.GetUserByuserName(Context.User.Identity.Name);
            await _chatRoomService.UpdateIsNotOnlineUser(user);

            var adminIds = await _chatRoomService.GetAdminUsersByUserId(user.Id);
            await _supportHub.Clients.Users(adminIds).SendAsync("disableOnlineUser", user.Id);
        }
        #endregion
        #region Other methods
        public async Task SelectAdminClient(string adminId)
        {

            string _RoomId = "";
            var user = await _accountService.GetUserByuserName(Context.User.Identity.Name);
            var adminUser = await _accountService.GetUserByuserId(adminId);
            var isExistChatRoom = await _chatRoomService.IsExistChatRoom(user.Id, adminUser.Id);

            if (!isExistChatRoom)
            {
                //Not Is Exist Room
                var resultCreate = await _chatRoomService.CreateChatRoom(user.Id, adminUser.Id);
                if (resultCreate)
                {
                    var room = await _chatRoomService.GetChatRoom(user.Id, adminUser.Id);
                    _RoomId = room.Id.ToString();
                    var clients = await _chatRoomService.GetUsersByAdminId(adminUser.Id);
                   await _supportHub.Clients.Client(adminUser.ConnectionId).SendAsync("GetClientsForAdmin", clients);
                }
            }
            else
            {
                //Is Exist Room
                var room = await _chatRoomService.GetChatRoom(user.Id, adminUser.Id);
                _RoomId = room.Id.ToString();

                var messages = await _messageService.GetChatMessage(room.Id);
                await Clients.Caller.SendAsync("getNewMessages", messages);
            }

            await Clients.Caller.SendAsync("getConnectionIds", user.ConnectionId, adminUser.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, _RoomId);

        }

        public async Task SendNewMessage(string adminId, string message)
        {
            var user = await _accountService.GetUserByuserName(Context.User.Identity.Name);
            var userAdmin = await _accountService.GetUserByuserId(adminId);
            var room = await _chatRoomService.GetChatRoom(user.Id, adminId);
            ChatMessage _message = new ChatMessage()
            {
                MessageChat = message,
                ChatRoomId = room.Id,
                Time = DateTime.Now,
                UserId = user.Id,
                TypeText = TypeText.Text
            };
            await _messageService.SaveChatMessage(room.Id, _message);

            var _messageDto = new MessageDto()
            {

                MessageText = message,
                Date = DateTime.Now.ToShamsi(),
                Time = DateTime.Now.ToShortTimeString(),
                User = user.FullName ?? user.PhoneNumber,
                IsAdmin = false,
                AvatarImage = user.AvatarImage

            };

            await Clients.Caller.SendAsync("getNewMessage", _messageDto);
            var groups = Clients.Group(room.Id.ToString());
            await _supportHub.Clients.Group(room.Id.ToString()).SendAsync("getNewMessage", _messageDto);
        }

        [Authorize]
        public async Task LeaveGrop(string activeAdminId)
        {
            var user = await _accountService.GetUserByuserName(Context.User.Identity.Name);
            var room = await _chatRoomService.GetChatRoom(user.Id, activeAdminId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, room.Id.ToString());
        }


        #endregion
    }
}
