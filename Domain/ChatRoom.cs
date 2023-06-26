
namespace Domain;
[Auditable]
public class ChatRoom
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string AdminId { get; set; }

    public ICollection<ChatMessage> ChatMessages { get; set; }
}

