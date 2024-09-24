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
        var bookmarkResponseModels = bookmarks.Select(b => b.ToBookmarkResponseModel()).ToList();
        return Ok(bookmarkResponseModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var bookmark = await _repo.GetByIdAsync(id);
        if (bookmark == null) return NotFound();
        var bookmarkResponse = bookmark.ToBookmarkResponseModel();
        bookmarkResponse.Post = bookmark.Post.ToPostResponseModel();
        return Ok(bookmarkResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookmarkRequestModel bookmarkRequestModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var bookmark = await _repo.CreateAsync(_userId!, bookmarkRequestModel);
        return CreatedAtAction(nameof(GetById), new { id = bookmark.Id }, bookmark.ToBookmarkResponseModel());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var bookmark = await _repo.GetByIdAsync(id);
        if (bookmark?.UserId != _userId)
            return NotFound("This bookmark does not exist or you do not have permission to delete this bookmark.");
        await _repo.DeleteAsync(id);
        return Ok("Bookmark deleted");
    }
}