using api.Data;
using api.Dtos.Post;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static api.Helpers.CurrentUserHelper;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostRepository _repo;
    private string? _userId;

    public PostController(IPostRepository repo, IUserRepository userRepository)
    {
        _repo = repo;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery query) // debug endpoint
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var posts = await _repo.GetAllOffsetAsync(query);
        var postResponseModels = posts.Select(s => s.ToPostResponseModel());
        return Ok(postResponseModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var post = await _repo.GetByIdAsync(id);
        if (post == null) return NotFound();
        return Ok(post.ToPostResponseModel());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] PostRequestModel postRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var post = await _repo.CreateAsync(postRequest, _userId!);
        return CreatedAtAction(nameof(GetById), new { id = post.Id }, post.ToPostResponseModel());
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, [FromBody] PostUpdateModel postUpdate)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var post = await _repo.GetByIdAsync(id);
        if (post?.UserId != _userId) return NotFound("You are not the author of this post or it does not exist");
        await _repo.UpdateAsync(id, postUpdate);
        return Ok($"Post {id} updated successfully");
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var post = await _repo.GetByIdAsync(id);
        if (post?.UserId != _userId) return NotFound("You are not the author of this post or it does not exist");
        await _repo.DeleteAsync(id);
        return Ok($"Post {id} deleted successfully");
    }
}