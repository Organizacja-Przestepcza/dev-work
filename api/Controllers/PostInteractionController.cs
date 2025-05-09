using System.ComponentModel.DataAnnotations;
using api.Dtos.PostInteraction;
using api.Enums;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static api.Helpers.CurrentUserHelper;

namespace api.Controllers;

[Route("api")]
[ApiController]
public class PostInteractionController : ControllerBase
{
    private readonly IPostInteractionRepository _repo;
    private string? _userId;
    private const string InvalidTypeError = "Invalid type. Accepted values are 0 (like) or 1 (dislike)";

    public PostInteractionController(IPostInteractionRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("posts/{postId}/reactions")]
    public async Task<IActionResult> GetAllForPost(string postId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var reactionSummary = await _repo.GetAllForPostAsync(postId);
        return Ok(reactionSummary);
    }

    [HttpGet("users/{userId}/reactions")]
    public async Task<IActionResult> GetAllForUser([FromQuery] [Required] int type, string userId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var reactions = await _repo.GetAllForUserAsync(type, userId);
        if (reactions.Count == 0) return NoContent();
        var reactionsResponses = reactions.Select(x => x.ToPostInteractionResponseModel()).ToList();
        return Ok(reactionsResponses);
    }

    [HttpGet("posts/{postId}/reaction")]
    public async Task<IActionResult> GetByPostId(string postId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var postInteraction = await _repo.GetByIdAsync(postId, _userId);
        if (postInteraction == null) return NotFound();
        return Ok(postInteraction.ToPostInteractionResponseModel());
    }


    [HttpPut("posts/{postId}/reaction")]
    [Authorize]
    public async Task<IActionResult> Update([FromQuery] [Required] int type, string postId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        if (type is not (0 or 1)) return BadRequest(InvalidTypeError);
        var update = new PostInteractionUpdateModel
        {
            PostId = postId,
            UserId = _userId!,
            Type = (InteractionType)type
        };
        var postInteraction = await _repo.CreateUpdateAsync(update);
        if (postInteraction == null) return NotFound("This post does not exist");
        return Ok($"You have {(type == 0 ? "like" : "dislike")}d this post");
    }

    [HttpDelete("posts/{postId}/reaction")]
    [Authorize]
    public async Task<IActionResult> Delete(string postId) // this endpoint might be removed
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        await _repo.DeleteAsync(postId, _userId);
        return Ok("Reaction removed successfully");
    }
}