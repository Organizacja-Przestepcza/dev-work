using api.Data;
using api.Dtos.Chat;
using api.Dtos.ChatMember;
using api.Enums;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/chat")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IChatRepository _repo;
    private readonly IMemberRepository _memberRepo;
    private readonly IUserRepository _userRepo;

    public ChatController(IChatRepository repo, IMemberRepository memberRepo, IUserRepository userRepo)
    {
        _repo = repo;
        _memberRepo = memberRepo;
        _userRepo = userRepo;
    }

    [HttpGet]
    [Authorize /*(Policy = IdentityData.RequireAdminPolicyName)*/]
    public async Task<IActionResult> GetAll() // debug endpoint
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var chats = await _repo.GetAllAsync();
        var chatResponseModels = chats.Select(s => s.ToChatResponseModel());
        return Ok(chatResponseModels);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var chat = await _repo.GetByIdAsync(id);
        if (chat == null) return NotFound();
        return Ok(chat.ToChatResponseModel());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] ChatRequestModel chatRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var user = await _userRepo.GetByIdAsync(chatRequest.UserId);
        if (user == null) return BadRequest($"User {chatRequest.UserId} doesn't exist");
        var chat = await _repo.CreateAsync(chatRequest);
        var member = _memberRepo.AddAsync(new ChatMemberRequestModel
        {
            ChatId = chat.Id,
            UserId = user.Id,
            Role = Role.Owner
        });
        return Ok($"Chat {chat.Id} created successfully with user {user.Id} as its owner");
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, [FromBody] ChatUpdateModel chatUpdate)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var chat = await _repo.UpdateAsync(id, chatUpdate);
        if (chat == null) return NotFound();
        return Ok(chat.ToChatResponseModel());
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var chat = await _repo.DeleteAsync(id);
        if (chat == null) return NotFound();
        return Ok($"Chat \"{chat.Name}\" deleted");
    }
}