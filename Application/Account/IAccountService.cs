
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Application.Account;

public interface IAccountService
{
    Task<IdentityResult> RegisterAsync(RegisterLoginDto registerLoginDto);
    Task<User> IsExistUserAsync(RegisterLoginDto registerLoginDto);
    Task<IdentityResult> UpdatePasswordUserAsync(RegisterLoginDto registerLoginDto);
    Task<IList<string>> GetRoleNameByUsername(string userName);
    Task<User> GetUserByuserName(string userName);

    Task<User> GetUserByuserId(string userId);
    Task<IdentityResult> UpdateConnectionIdForUser(string userId, string connectionId);

    
    Task<SignInResult> SignAsync(RegisterLoginDto registerLoginDto);
    bool IsSignin(ClaimsPrincipal claim);
    Task SignOutAsync();

}
