using api.Dtos.Account;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController(UserManager<AppUser> userManager) : ControllerBase
{
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

            var createdUser = await userManager.CreateAsync(appUser, registerRequest.Password);

            if (!createdUser.Succeeded)
            {
                return BadRequest(createdUser.Errors);
            }

            var roleResult = await userManager.AddToRoleAsync(appUser, "Member");
            if (!roleResult.Succeeded)
            {
                return BadRequest(roleResult.Errors);
            }

            return Ok("User created.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}