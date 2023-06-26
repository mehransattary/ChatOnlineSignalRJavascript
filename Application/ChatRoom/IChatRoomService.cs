

using Application.Message;
using Domain;

namespace Application.ChatRoom;

public interface IChatRoomService
{
    Task<bool> CreateChatRoom(string userId1, string userId2);
    Task<Domain.ChatRoom> GetChatRoom(string userId, string adminId);
    Task<List<MessageDto>> GetMessagesByChatRoom(string userId, string adminId);
    Task<bool> IsExistChatRoom(string userId, string adminId);
    Task<IList<User>> GetAdminClients();
    Task<List<User>> GetUsersByAdminId(string adminId);
    Task<IReadOnlyList<string>> GetAdminUsersByUserId(string userId);
    Task<IReadOnlyList<string>> GetUsersByAdminUserId(string userId);
    Task<User> UpdateIsOnlineUser(User user);
    Task<User> UpdateIsNotOnlineUser(User user);
    Task<IList<User>> GetExperts();
    Task UpdateConnectionId(User user, string newConnectionId);

}
