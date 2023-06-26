

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Auditable]
public class ChatMessage
{
    public Guid Id { get; set; }
    public string MessageChat { get; set; }
    public TypeText TypeText { get; set; }
    public Guid ChatRoomId { get; set; }
    public bool IsAdmin { get; set; }

    public string UserId { get; set; }
    public DateTime Time { get; set; }

    public ChatRoom ChatRoom { get; set; }


    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

}
public enum TypeText
{
    Text,
    File
}
