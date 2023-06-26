using Microsoft.AspNetCore.Identity;


namespace Domain;
public class User : IdentityUser
{
    public string? FullName { get; set; }
    public string? AvatarImage { get; set; }
    public string? Branche { get; set; }
    public string? ConnectionId { get; set; }
    public string? CodeDispo { get; set; }
    public bool IsOnline { get; set; } = false;
    public bool IsAdmin { get; set; } = false;


}
