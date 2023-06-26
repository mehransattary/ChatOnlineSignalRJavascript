
using Common.Security;
using Domain;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Application.Account;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signIn;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AccountService(
      UserManager<User> userManager,
      SignInManager<User> signIn,
      RoleManager<IdentityRole> roleManager
      )

    {
        _userManager = userManager;
        _signIn = signIn;
        _roleManager = roleManager;

    }
 

    public bool IsSignin(ClaimsPrincipal claim)
    {
        return _signIn.IsSignedIn(claim);
    }

    public async Task<IdentityResult> RegisterAsync(RegisterLoginDto registerLoginDto)
    {     
       
        User user = new User()
        {
            PhoneNumber = registerLoginDto.Mobile,
            UserName = registerLoginDto.Mobile,
            CodeDispo= registerLoginDto.Password,
            AvatarImage="/images/User.png"
        };
        var result = await _userManager.CreateAsync(user, registerLoginDto.Password);
        return await _userManager.AddToRoleAsync(user, "user");
    }
    public async Task<User> GetUserByuserName(string userName)
    {
        return await _userManager.FindByNameAsync(userName);
    }
    public async Task<User> GetUserByuserId(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }
    public async Task<IdentityResult> UpdateConnectionIdForUser(string userId,string connectionId)
    {
        var user = await GetUserByuserId(userId);
        user.ConnectionId = connectionId;
        return await _userManager.UpdateAsync(user);
    }

    public async Task<SignInResult> SignAsync(RegisterLoginDto registerLoginDto)
    {
       var isExistUser= await IsExistUserAsync(registerLoginDto);
        return await _signIn.PasswordSignInAsync(isExistUser, registerLoginDto.Password, true, lockoutOnFailure: false);
    }
    public async Task<IdentityResult> UpdatePasswordUserAsync(RegisterLoginDto registerLoginDto)
    {
        var isExistUser = await IsExistUserAsync(registerLoginDto);     
        var res= await _userManager.ChangePasswordAsync(isExistUser, isExistUser.CodeDispo, registerLoginDto.Password);
        isExistUser.CodeDispo = registerLoginDto.Password;
        await _userManager.UpdateAsync(isExistUser);
        return res;
    }
    public async Task<User> IsExistUserAsync(RegisterLoginDto registerLoginDto)
    {
        return await _userManager.FindByNameAsync(registerLoginDto.Mobile);
    }
    public async Task SignOutAsync()
    {
        await _signIn.SignOutAsync();
    }

    public async Task<IList<string>> GetRoleNameByUsername(string userName)
    {
        var user = await GetUserByuserName(userName);
      var res= await _userManager.GetRolesAsync(user);
        return res;

    }
}
