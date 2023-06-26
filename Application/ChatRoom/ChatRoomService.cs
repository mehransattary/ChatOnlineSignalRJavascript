

using Application.Interfaces.Contexts;
using Application.Message;
using Common.Utilities;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Application.ChatRoom;

public class ChatRoomService : IChatRoomService
{
    #region Constructor
    private readonly IDataBaseContext _context;
    private readonly UserManager<User> _userManager;

    public ChatRoomService(IDataBaseContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    #endregion


    public async Task<bool> CreateChatRoom(string userId, string adminId)
    {
        var isExistChatRoom = await IsExistChatRoom(userId, adminId);
        if (!isExistChatRoom)
        {
            var room = new Domain.ChatRoom()
            {
                UserId = userId,
                AdminId = adminId,
                Id = Guid.NewGuid(),
            };
            await _context.ChatRooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;

    }
    public async Task<Domain.ChatRoom> GetChatRoom(string userId, string adminId)
    {
        var chatRoom = await IsExistChatRoom(userId, adminId);
        if (chatRoom)
        {
            var room = await _context.ChatRooms.FirstOrDefaultAsync(x => x.UserId == userId && x.AdminId == adminId);
            return room;
        }
        return null;
    }
    public async Task<List<MessageDto>> GetMessagesByChatRoom(string userId, string adminId)
    {
        Domain.ChatRoom room = new Domain.ChatRoom();
        if (IsExistChatRoom(userId, adminId).Result)
        {
            room = await GetChatRoom(userId, adminId);
        }
        else
        {
            var res = await CreateChatRoom(userId, adminId);
            if (res)
            {
                room = await GetChatRoom(userId, adminId);
            }
        }

        var messages = await _context.ChatMessages.Where(x => x.ChatRoomId == room.Id).Select(x => new MessageDto
        {
            Id = x.Id,
            MessageText = x.MessageChat,
            Date = x.Time.ToShamsi(),
            Time = x.Time.ToShortTimeString(),
            User = x.User.FullName ?? x.User.PhoneNumber,
            IsAdmin = x.IsAdmin,
            AvatarImage = x.User.AvatarImage
        }).ToListAsync();
        return messages;

    }
    public async Task<bool> IsExistChatRoom(string userId, string adminId)
    {
        return await _context.ChatRooms.AnyAsync(p => p.UserId == userId && p.AdminId == adminId);
    }
    public async Task<IList<User>> GetAdminClients()
    {
        var clients = await _userManager.GetUsersInRoleAsync("admin");
        return await Task.FromResult(clients);
    }

    public async Task<List<User>> GetUsersByAdminId(string adminId)
    {
        var rooms = await _context.ChatRooms.Where(x => x.AdminId == adminId).ToListAsync();

        List<string> users = new List<string>();
        var userIds = rooms.Select(x => x.UserId).ToList();     

        return await _userManager.Users
   .Where(x => userIds.Contains(x.Id) ).OrderByDescending(x => x.IsOnline)
   .ToListAsync();
    }

    public async Task<IReadOnlyList<string>> GetAdminUsersByUserId(string userId)
    {
        return await _context.ChatRooms.Where(x => x.UserId == userId).Select(x => x.AdminId).ToListAsync();
    }
    public async Task<IReadOnlyList<string>> GetUsersByAdminUserId(string adminId)
    {
        return await _context.ChatRooms.Where(x => x.AdminId == adminId).Select(x => x.UserId).ToListAsync();
    }
    public async Task<User> UpdateIsOnlineUser(User user)
    {
        user.IsOnline = true;
        await _userManager.UpdateAsync(user);
        return user;
    }
    public async Task<User> UpdateIsNotOnlineUser(User user)
    {
        user.IsOnline = false;
        await _userManager.UpdateAsync(user);
        return user;
    }
    public async Task UpdateConnectionId(User user, string newConnectionId)
    {
        if (!(user is null) && newConnectionId != "")
        {
            user.ConnectionId = newConnectionId;
            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IList<User>> GetExperts()
    {
        var res = await _userManager.GetUsersInRoleAsync("admin");
        return res;
    }


}
