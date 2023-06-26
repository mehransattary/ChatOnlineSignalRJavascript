using Application.Interfaces.Contexts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Common.Utilities;

namespace Application.Message;

public class MessageService : IMessageService
{
    private readonly IDataBaseContext _context;
    public MessageService(IDataBaseContext context)
    {
        _context = context;
    }

    public async Task<List<MessageDto>> GetChatMessage(Guid RoomId)
    {
        var messages= await _context.ChatMessages.Include(x=>x.User).Where(p => p.ChatRoomId == RoomId).OrderBy(p => p.Time).ToListAsync();
        //.Select(x => new MessageDto
        // {
        //     Id = x.Id,
        //     MessageText = x.MessageChat,
        //     Date = x.Time.ToShamsi(),
        //     Time = x.Time.ToShortTimeString(),
        //     User = x.User.FullName ?? x.User.PhoneNumber,
        //     IsAdmin = x.IsAdmin,
        //     AvatarImage = x.User.AvatarImage
        // }
        var _messages = messages.Select(x => new MessageDto
        {
            Id = x.Id,
            MessageText = x.MessageChat,
            Date = x.Time.ToShamsi(),
            Time = x.Time.ToShortTimeString(),
            User = x.User.FullName ?? x.User.PhoneNumber,
            IsAdmin = x.IsAdmin,
            AvatarImage = x.User.AvatarImage
        });
        return _messages.ToList();
    }

    public async Task SaveChatMessage(Guid RoomId, ChatMessage message)
    {
        var room = _context.ChatRooms.SingleOrDefault(p => p.Id == RoomId);
        ChatMessage chatMessage = new ChatMessage()
        {
            ChatRoom = room,
            Time = message.Time,
            MessageChat= message.MessageChat,
            ChatRoomId= room.Id,
            IsAdmin= message.IsAdmin,
            TypeText= message.TypeText,
            UserId= message.UserId  ,
            
        };
        _context.ChatMessages.Add(chatMessage);
        _context.SaveChanges();
    }
}
