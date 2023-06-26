

namespace Application.Message;

public class MessageDto
{
    public Guid Id { get; set; }
    public string AvatarImage { get; set; }

    public string User { get; set; }
    public string MessageText { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }

    public bool IsAdmin { get; set; }


}
