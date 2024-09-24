using api.Data;
using api.Dtos;
using api.Dtos.Account;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;
    private string? _userId;

    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService,
        SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginRequestModel.Username);
        if (user == null) return Unauthorized("Invalid username");
        var roles = await _userManager.GetRolesAsync(user) as List<string>;
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequestModel.Password, false);
        if (!result.Succeeded) return Unauthorized("Invalid password");
        return Ok(
            new LoginResponseModel
            {
                Username = loginRequestModel.Username,
                Token = _tokenService.CreateToken(new TokenData(user, roles))
            });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestModel registerRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var appUser = new AppUser
        {
            UserName = registerRequest.Username,
            Email = registerRequest.Email
        };

        var createdUser = await _userManager.CreateAsync(appUser, registerRequest.Password);

        if (!createdUser.Succeeded) return BadRequest(createdUser.Errors);

        var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
        if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);

        return Ok(
            new RegisterResponseModel
            {
                Username = registerRequest.Username,
                Email = registerRequest.Email,
                Token = _tokenService.CreateToken(new TokenData(appUser, ["User"]))
            }
        );
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteSelf()
    {
        _userId = CurrentUserHelper.GetCurrentUserId(HttpContext);
        var user = await _userManager.FindByIdAsync(_userId!);
        if (user == null) return NotFound("You should not see this");
        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded) return BadRequest("Failed to delete your account");
        return Ok("Your account has been deleted");
    }

    [HttpDelete("{userId}")]
    [Authorize(Policy = IdentityData.RequireAdminPolicyName)]
    public async Task<IActionResult> Delete(string userId)
    {
        // Needs a refactor when middleware error handling is implemented
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded) return BadRequest("Failed to delete user");

            return Ok($"User {user.UserName} deleted");
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "An error occurred while processing your request");
        }
    }
}