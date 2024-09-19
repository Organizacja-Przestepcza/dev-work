using api.Data;
using api.Dtos.AppUser;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repo;

    public UserController(IUserRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [Authorize(Policy = IdentityData.RequireAdminPolicyName)]
    public async Task<IActionResult> GetAll() // debug
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var users = await _repo.GetAllAsync();
        var userResponseModels = users.Select(s => s.ToUserResponseModel());
        return Ok(userResponseModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var user = await _repo.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user.ToUserResponseModel());
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, [FromBody] UserUpdateModel userUpdate)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var user = await _repo.UpdateAsync(id, userUpdate);
        if (user == null) return NotFound();
        return Ok(user.ToUserResponseModel());
    }
}