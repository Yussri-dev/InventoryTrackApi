using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryTrackApi.Controllers.Authentification
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalAuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public ExternalAuthController(UserManager<ApplicationUser> userManager,
                                      SignInManager<ApplicationUser> signInManager,
                                      ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        //[HttpGet("signin-google")]
        //public IActionResult SignInWithGoogle()
        //{
        //    var redirectUrl = "https://localhost:5001/api/ExternalAuth/google-response";
        //    var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
        //    return Challenge(properties, "Google");
        //}


        //[HttpGet("signin-google")]
        //public IActionResult SignInWithGoogle()
        //{
        //    var redirectUrl = Url.Action(nameof(HandleGoogleResponse));
        //    var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
        //    return Challenge(properties, "Google");
        //}

        //[HttpGet("signin-google")]
        //public IActionResult SignInWithGoogle()
        //{
        //    //var redirectUrl = Url.Action(nameof(HandleGoogleResponse));
        //    var redirectUrl = Url.Action(nameof(HandleGoogleResponse), "externalauth", null, Request.Scheme);

        //    Console.WriteLine("" + redirectUrl);

        //    var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
        //    return Challenge(properties, "Google");
        //}

        //[HttpGet("google-response")]
        //public async Task<IActionResult> HandleGoogleResponse()
        //{
        //    var info = await _signInManager.GetExternalLoginInfoAsync();
        //    if (info == null)
        //        return BadRequest("Error loading external login info");

        //    var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
        //    ApplicationUser user;

        //    if (!result.Succeeded)
        //    {
        //        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        //        user = await _userManager.FindByEmailAsync(email);

        //        if (user == null)
        //        {
        //            user = new ApplicationUser
        //            {
        //                UserName = email,
        //                Email = email
        //            };
        //            var createResult = await _userManager.CreateAsync(user);
        //            if (!createResult.Succeeded)
        //                return BadRequest(createResult.Errors);

        //            await _userManager.AddLoginAsync(user, info);
        //        }
        //    }
        //    else
        //    {
        //        user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
        //    }

        //    var id = await _userManager.GetUserIdAsync(user);
        //    var token = _tokenService.GenerateJwtToken(id, user.UserName, roles);

        //    return Ok(new AuthResponseDto
        //    {
        //        IsSuccess = true,
        //        UserName = user.UserName,
        //        IdUser = id,
        //        Token = token
        //    });
        //}
    }

}
