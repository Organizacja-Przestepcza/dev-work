using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static api.Helpers.CurrentUserHelper;

namespace api.Controllers;

[Route("api/user/{id}")]
[ApiController]
[Authorize]
public class ConnectionController : ControllerBase
{
    private readonly IConnectionRepository _repo;
    private readonly IUserRepository _userRepo;
    private string? _userId;

    public ConnectionController(IConnectionRepository repo, IUserRepository userRepo)
    {
        _repo = repo;
        _userRepo = userRepo;
    }

    [HttpGet("followers")]
    public async Task<IActionResult> GetFollowers(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var followers = await _repo.GetFollowers(id);
        var followersResponseModels = followers.Select(f => f.ToConnectionResponseModel()).ToList();
        return Ok(followersResponseModels);
    }

    [HttpGet("following")]
    public async Task<IActionResult> GetFollowings(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var followers = await _repo.GetFollowings(id);
        var followersResponseModels = followers.Select(f => f.ToConnectionResponseModel()).ToList();
        return Ok(followersResponseModels);
    }

    [HttpGet("follow")]
    public async Task<IActionResult> GetStatus(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null) return BadRequest("This user does not exist");
        var connection = await _repo.GetByIdAsync(_userId!, id);
        if (connection == null) return NotFound("You are not following this user");
        return Ok($"You are following this user since {connection.CreatedAt.ToShortDateString()}");
    }

    [HttpPost("follow")]
    public async Task<IActionResult> Follow(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null) return BadRequest("This user does not exist");
        var connection = await _repo.CreateAsync(_userId!, id);
        if (connection == null) return BadRequest("You are already following this user");
        return Ok("You are now following this user");
    }

    [HttpDelete("follow")]
    public async Task<IActionResult> Unfollow(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null) return BadRequest("This user does not exist");
        var connection = await _repo.DeleteAsync(_userId!, id);
        if (connection == null) return NotFound("You are not following this user");
        return Ok("You are no longer following this user");
    }
}