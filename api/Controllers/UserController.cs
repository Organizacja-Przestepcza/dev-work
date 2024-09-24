using api.Dtos.AppUser;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static api.Helpers.CurrentUserHelper;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repo;
    private string? _userId;

    public UserController(IUserRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("all")]
    [Authorize /*(Policy = IdentityData.RequireAdminPolicyName)*/]
    public async Task<IActionResult> GetAll() // debug
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var users = await _repo.GetAllAsync();
        var userResponseModels = users.Select(s => s.ToUserResponseModel());
        return Ok(userResponseModels);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var user = await _repo.GetByIdAsync(_userId!);
        if (user == null) return Unauthorized();
        return Ok(user.ToUserResponseModel());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var user = await _repo.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user.ToUserResponseModel());
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UserUpdateModel userUpdate)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var user = await _repo.UpdateAsync(_userId!, userUpdate);
        if (user == null) return NotFound();
        return Ok(user.ToUserResponseModel());
    }
}