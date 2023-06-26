

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Application.Account;

public class RegisterLoginDto
{
    [Display(Name = "موبایل")]
    public string Mobile { get; set; }
    [DataType(DataType.Password)]
    [Display(Name = "رمز عبور")]
    public string? Password { get; set; }
}
