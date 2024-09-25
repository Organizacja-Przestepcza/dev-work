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
    private readonly IBookmarkRepository _bookmarkRepo;
    private string? _userId;

    public PostController(IPostRepository repo, IBookmarkRepository bookmarkRepo)
    {
        _repo = repo;
        _bookmarkRepo = bookmarkRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery query)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var postResponseModels = await _repo.GetAllOffsetAsync(query);
        var postIds = postResponseModels.Select(p => p.Id).ToList();
        var bookmarks = await _bookmarkRepo.GetForListAsync(postIds, _userId);
        foreach (var post in postResponseModels)
        {
            var matchingBookmark = bookmarks.FirstOrDefault(b => b.PostId == post.Id);
            if (matchingBookmark != null) post.Bookmark = matchingBookmark.ToBookmarkResponseModel();
        }

        return Ok(postResponseModels);
    }

    [HttpGet("{id}/comments")]
    public async Task<IActionResult> GetComments([FromRoute] string id, [FromQuery] PaginationQuery query)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var postResponseModels = await _repo.GetCommentsOffsetAsync(id, query);
        var postIds = postResponseModels.Select(p => p.Id).ToList();
        var bookmarks = await _bookmarkRepo.GetForListAsync(postIds, _userId);
        foreach (var post in postResponseModels)
        {
            var matchingBookmark = bookmarks.FirstOrDefault(b => b.PostId == post.Id);
            if (matchingBookmark != null) post.Bookmark = matchingBookmark.ToBookmarkResponseModel();
        }

        return Ok(postResponseModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var postResponseModel = await _repo.GetResponseModelByIdAsync(id);
        if (postResponseModel == null) return NotFound();
        var bookmark = await _bookmarkRepo.GetByIdAsync(_userId, postResponseModel.Id);
        if (bookmark != null) postResponseModel.Bookmark = bookmark.ToBookmarkResponseModel();
        return Ok(postResponseModel);
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