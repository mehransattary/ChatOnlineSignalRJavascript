using Application.Account;
using Application.ChatRoom;
using Application.Message;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Common.Utilities;
namespace Hubs;

[Authorize]
public class SupportHub : Hub
{
    #region Constructor
    private readonly IChatRoomService _chatRoomService;
    private readonly IMessageService _messageService;
    private readonly IAccountService _accountService;

    private readonly IHubContext<SiteChatHub> _siteChathub;
    public SupportHub(IChatRoomService chatRoomService,
        IMessageService messageService
        , IHubContext<SiteChatHub> hubContext,
        IAccountService accountService)
    {
        _chatRoomService = chatRoomService;
        _messageService = messageService;
        _siteChathub = hubContext;
        _accountService = accountService;

    }
    #endregion
    #region OnConnected And Disconnected
    public async override Task OnConnectedAsync()
    {
        var roles = await _accountService.GetRoleNameByUsername(Context.User.Identity.Name);
        if (roles.Contains("admin"))
        {
            var adminUser = await _accountService.GetUserByuserName(Context.User.Identity.Name);
            await _chatRoomService.UpdateIsOnlineUser(adminUser);

            #region Update AdminConnectionId
            await _chatRoomService.UpdateConnectionId(adminUser, Context.ConnectionId);
            var UserIds = await _chatRoomService.GetUsersByAdminUserId(adminUser.Id);
            await _siteChathub.Clients.Users(UserIds).SendAsync("UserConnected", adminUser.Id);
            #endregion
            var clients = await _chatRoomService.GetUsersByAdminId(adminUser.Id);
            await Clients.Caller.SendAsync("GetClientsForAdmin", clients);
            await GetExperts();
            await GetCustomers();

        }
        await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var adminUser = await _accountService.GetUserByuserName(Context.User.Identity.Name);
        await _chatRoomService.UpdateIsNotOnlineUser(adminUser);
        var UserIds = await _chatRoomService.GetUsersByAdminUserId(adminUser.Id);
        await _siteChathub.Clients.Users(UserIds).SendAsync("disableOnlineUser", adminUser.Id);
    }


    #endregion
    #region Other methods

    public async Task LoadMessages(string userId)
    {
        var adminUser = await _accountService.GetUserByuserName(Context.User.Identity.Name);
        var user = await _accountService.GetUserByuserId(userId);
        //set connectionIds
        await Clients.Caller.SendAsync("getConnectionIds", user.ConnectionId, adminUser.ConnectionId);
        var messsages = await _chatRoomService.GetMessagesByChatRoom(userId, adminUser.Id);
        //get messages
        await Clients.Caller.SendAsync("getNewMessages", messsages);
        var room = await _chatRoomService.GetChatRoom(userId, adminUser.Id);
        //add group
        await Groups.AddToGroupAsync(Context.ConnectionId, room.Id.ToString());
    }
    public async Task SendNewMessage(string userId, string message)
    {
        var user = await _accountService.GetUserByuserId(userId);
        var adminUser = await _accountService.GetUserByuserName(Context.User.Identity.Name);
        //get room
        var room = await _chatRoomService.GetChatRoom(userId, adminUser.Id);
        //save message
        ChatMessage _message = new ChatMessage()
        {
            MessageChat = message,
            ChatRoomId = room.Id,
            Time = DateTime.Now,
            UserId = adminUser.Id,
            TypeText = TypeText.Text,
            IsAdmin = true
        };
        await _messageService.SaveChatMessage(room.Id, _message);
        MessageDto _messageDto = new MessageDto()
        {
            MessageText = message,
            AvatarImage = adminUser.AvatarImage,
            Time = _message.Time.ToShortTimeString(),
            Date = _message.Time.ToShamsi(),
            IsAdmin = true,
            User = adminUser.FullName ?? adminUser.PhoneNumber,
        };
        //get message
        var groups = Clients.Group(room.Id.ToString());
        await Clients.Caller.SendAsync("getNewMessage", _messageDto);
        await _siteChathub.Clients.Group(room.Id.ToString()).SendAsync("getNewMessage", _messageDto);

    }


    public async Task LeaveGrop(string activeUserId)
    {
        var userAdmin = await _accountService.GetUserByuserName(Context.User.Identity.Name);
        var room = await _chatRoomService.GetChatRoom(activeUserId, userAdmin.Id);
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, room.Id.ToString());
    }
    public async Task GetExperts()
    {
        var experts = await _chatRoomService.GetExperts();
        var result_ordered = experts.OrderBy(x => x.Branche);
        await Clients.Caller.SendAsync("GetExperts", result_ordered);

    }
    public async Task GetCustomers()
    {
        var adminUser = await _accountService.GetUserByuserName(Context.User.Identity.Name);
        var clients = await _chatRoomService.GetUsersByAdminId(adminUser.Id);
        await Clients.Caller.SendAsync("GetCustomers", clients);
    }
    public async Task<User> GetClientById(string clientId)
    {
        var client =await _accountService.GetUserByuserId(clientId);
        return client;
    }
    #endregion
}
