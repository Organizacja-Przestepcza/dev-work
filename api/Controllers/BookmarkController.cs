using api.Dtos.Bookmark;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static api.Helpers.CurrentUserHelper;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
[Authorize]
public class BookmarkController : ControllerBase
{
    private readonly IBookmarkRepository _repo;
    private string? _userId;

    public BookmarkController(IBookmarkRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var bookmarks = await _repo.GetAllAsync(_userId!);
        var bookmarkResponseModels = bookmarks.Select(b => new BookmarkResponseModel
        {
            CreatedAt = DateTime.Now,
            Post = b.Post.ToPostResponseModel(),
            UserId = b.UserId
        }).ToList();
        return Ok(bookmarkResponseModels);
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetById(string postId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var bookmark = await _repo.GetByIdAsync(_userId!, postId);
        if (bookmark == null) return NotFound();
        var bookmarkResponse = new BookmarkResponseModel
        {
            CreatedAt = bookmark.CreatedAt,
            UserId = bookmark.UserId
        };
        return Ok(bookmarkResponse);
    }

    [HttpPost("{postId}")]
    public async Task<IActionResult> Create(string postId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var bookmark = await _repo.CreateAsync(_userId!, postId);
        if (bookmark == null) return BadRequest("You have already bookmarked this post");
        return Ok();
    }

    [HttpDelete("{postId}")]
    public async Task<IActionResult> Delete(string postId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var bookmark = await _repo.GetByIdAsync(_userId!, postId);
        if (bookmark == null)
            return NotFound("This bookmark does not exist or you do not have permission to delete it.");
        await _repo.DeleteAsync(_userId!, postId);
        return Ok("Bookmark deleted");
    }
}