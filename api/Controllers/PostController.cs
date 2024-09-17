using api.Dtos.Post;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/post")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostRepository _repo;

    public PostController(IPostRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [Authorize(Policy = "RequireAdminRole")]
    public async Task<IActionResult> GetAll() // debug endpoint
    {
        var posts = await _repo.GetAllAsync();
        var postResponseModels = posts.Select(s => s.ToPostResponseModel());
        return Ok(postResponseModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var post = await _repo.GetByIdAsync(id);
        if (post == null) return NotFound();
        return Ok(post.ToPostResponseModel());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] PostRequestModel postRequest)
    {
        var post = await _repo.CreateAsync(postRequest);
        return Ok(post.ToPostResponseModel());
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, [FromBody] PostUpdateModel postUpdate)
    {
        var post = await _repo.UpdateAsync(id, postUpdate);
        if (post == null) return NotFound();
        return Ok(post.ToPostResponseModel());
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var post = await _repo.DeleteAsync(id);
        if (post == null) return NotFound();
        return Ok($"Post {id} deleted");
    }
}