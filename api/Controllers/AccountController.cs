using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManager;
    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = await _userManager.Users.FirstOrDefaultAsync(x=> x.Email == loginRequestModel.Email);
        if (user == null)
        {
            return Unauthorized("Invalid username");
        }
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequestModel.Password, false);
        if (!result.Succeeded)
        {
            return Unauthorized("Invalid password");
        }
        return Ok(
            new LoginResponseModel
            {
                Email = loginRequestModel.Email,
                Token = _tokenService.CreateToken(user),
            });
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestModel registerRequest)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = new AppUser
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerRequest.Password);

            if (!createdUser.Succeeded)
            {
                return BadRequest(createdUser.Errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(appUser, "Member");
            if (!roleResult.Succeeded)
            {
                return BadRequest(roleResult.Errors);
            }

            return Ok(
                new RegisterResponseModel
                {
                    UserName = registerRequest.Username,
                    Email = registerRequest.Email,
                    Token = _tokenService.CreateToken(appUser),
                }
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}