using api.Dtos.Message;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static api.Helpers.CurrentUserHelper;

namespace api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMemberRepository _memberRepo;
    private readonly IMessageRepository _repo;
    private string? _userId;

    public MessageController(IMessageRepository repo, IChatRepository chatRepo, IUserRepository userRepo,
        IMemberRepository memberRepo)
    {
        _repo = repo;
        _memberRepo = memberRepo;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] string chatId) // debug endpoint
    {
        _userId = GetCurrentUserId(HttpContext);
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var messages = await _repo.GetAllAsync(chatId);
        var messageResponseModels = messages.Select(s => s.ToMessageResponseModel());

        return Ok(messageResponseModels);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var message = await _repo.GetByIdAsync(id);
        if (message == null) return NotFound("You do not have access to this message or it does not exist");
        var isMember = await _memberRepo.IsMemberAsync(message.ChatId, _userId!);
        if (!isMember) return NotFound("You do not have access to this message or it does not exist");
        return Ok(message.ToMessageResponseModel());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] MessageRequestModel messageRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var isMember = await _memberRepo.IsMemberAsync(messageRequest.ChatId, _userId!);
        if (!isMember) return NotFound("You are not a member of this chat or chat does not exist");
        var message = await _repo.CreateAsync(messageRequest, _userId!);
        return Ok($"Message {message.Id} sent");
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] MessageUpdateModel messageUpdate, string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var message = await _repo.GetByIdAsync(id);
        if (message?.UserId != _userId) return NotFound("You are not the owner of this message or it does not exist");
        await _repo.UpdateAsync(id, messageUpdate);
        return Ok($"Message {id} updated successfully");
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _userId = GetCurrentUserId(HttpContext);
        var message = await _repo.GetByIdAsync(id);
        if (message?.UserId != _userId) return NotFound("You are not the owner of this message or it does not exist");
        await _repo.DeleteAsync(id);
        return Ok($"Message {id} deleted successfully");
    }
}