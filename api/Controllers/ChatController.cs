using api.Dtos.Chat;
using api.Dtos.ChatMember;
using api.Enums;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static api.Helpers.CurrentUserHelper;

namespace api.Controllers;

[Route("api/chat")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IChatRepository _repo;
    private readonly IMemberRepository _memberRepo;
    private string? _userId;

    public ChatController(IChatRepository repo, IMemberRepository memberRepo)
    {
        _repo = repo;
        _memberRepo = memberRepo;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllForUser() // debug endpoint
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var chats = await _repo.GetAllForUserAsync(_userId!);
        var chatResponseModels = chats.Select(s => s.ToChatResponseModel());
        return Ok(chatResponseModels);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var isMember = await _memberRepo.IsMemberAsync(id, _userId!);
        if (!isMember) return NotFound("You are not a member of this chat or chat does not exist");
        var chat = await _repo.GetByIdAsync(id);
        return Ok(chat!.ToChatResponseModel());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] ChatRequestModel chatRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var chat = await _repo.CreateAsync(chatRequest);
        await _memberRepo.AddAsync(new ChatMemberRequestModel
        {
            ChatId = chat.Id,
            UserId = _userId!,
            Role = Role.Owner
        });
        return Ok($"Chat {chat.Id} created successfully with user {_userId} as its owner");
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, [FromBody] ChatUpdateModel chatUpdate)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var isPrivileged = await _memberRepo.IsPrivilegedAsync(id, _userId!);
        if (!isPrivileged) return NotFound("You do not have required permissions or chat does not exist");
        var chat = await _repo.UpdateAsync(id, chatUpdate);
        if (chat == null) return NotFound("You shouldn't be able to see this");
        return Ok(chat.ToChatResponseModel());
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var isOwner = await _memberRepo.IsOwnerAsync(id, _userId!);
        if (!isOwner) return NotFound("You are not the owner of this chat");
        var chat = await _repo.DeleteAsync(id);
        if (chat == null) return NotFound();
        return Ok($"Chat \"{chat.Name}\" deleted");
    }
}