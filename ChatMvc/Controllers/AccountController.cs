using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Common.Security;
using Microsoft.AspNetCore.Identity;
using Application.Account;
using Common.Convertor;
using Application.Sms;

namespace ChatMvc.Controllers;

[AutoValidateAntiforgeryToken]

public class AccountController : Controller
{
    #region //============Consreuctor===========//
          private readonly IAccountService accountService;
    private readonly ISmsService smsService;

    public AccountController(IAccountService accountService, ISmsService smsService)
    {
        this.accountService = accountService;
        this.smsService = smsService;

    }
    #endregion
  
    #region //============Register==============//
 
    [HttpGet]
    [Route("/RegisterDisposable/{ReturnUrl?}")]
    public IActionResult RegisterDisposable(string? ReturnUrl)
    {
        return View();
    }
    [Route("/RegisterDisposable")]   
    [HttpPost]
    public async Task<IActionResult> RegisterAsyncDisposable(RegisterLoginDto registerLoginDto)
    {
        if (ModelState.IsValid)
        {
           
            string random = RandomNumber.Random(1000, 10000).ToString();
            try
            {
                registerLoginDto.Password = random;
               await smsService.SendSms(registerLoginDto.Mobile, registerLoginDto.Password);
                var resIsExistUser = await accountService.IsExistUserAsync(registerLoginDto);

                if (resIsExistUser != null)
                {
                   var res= await accountService.UpdatePasswordUserAsync(registerLoginDto);
                    if(res.Succeeded)
                    {
                        return RedirectToAction(nameof(LoginDisposable), new { mobile = registerLoginDto.Mobile });
                    }
              
                }
     

                else
                {
                    var res = await accountService.RegisterAsync(registerLoginDto);
                    if(res.Succeeded)
                        return RedirectToAction(nameof(LoginDisposable), new { mobile = registerLoginDto.Mobile });
                    else
                        ModelState.AddModelError("Password", res.Errors.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("register err :"+ex.Message);
                throw;
            }
         
        }
        return View("RegisterDisposable", registerLoginDto);

    }
    #endregion

    #region //============Login=================//
    [Route("/LoginDisposable")]
    [HttpGet]
    public IActionResult LoginDisposable(string mobile)
    {
        ViewData["mobile"] = mobile;
        return View();
    }

    [Route("/LoginDisposable")]
    [HttpPost]
    public async Task<IActionResult> LoginDisposable(RegisterLoginDto registerLoginDto)
    {       
        ViewData["mobile"] = registerLoginDto.Mobile;
        if (ModelState.IsValid)
        {
            try
            {
                var res = await accountService.SignAsync(registerLoginDto);
                if (res.Succeeded)                
                    return Redirect("/"); 
            }
            catch (Exception ex)
            {
                throw;
            }
         
        }
        return View(registerLoginDto);
    }
    #endregion

    #region //============LogOut================//


    public IActionResult LogOut()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/RegisterDisposable");
    }
    #endregion

    #region //============AccessDenied==========//

    public IActionResult AccessDenied()
    {
        return View();
    }
    #endregion
}
