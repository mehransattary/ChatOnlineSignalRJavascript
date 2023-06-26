

using Domain;

namespace Application.Message;

public interface IMessageService
{
    Task SaveChatMessage(Guid RoomId, Domain.ChatMessage message);
    Task<List<MessageDto>> GetChatMessage(Guid RoomId);

}
