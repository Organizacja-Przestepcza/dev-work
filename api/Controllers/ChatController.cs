using api.Dtos.Chat;
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
    private readonly UserManager<AppUser> _userManager;

    public ChatController(IChatRepository repo, UserManager<AppUser> userManager)
    {
        _repo = repo;
        _userManager = userManager;
    }

    [HttpGet]
    [Authorize(Policy = "RequireAdminRole")]
    public async Task<IActionResult> GetAll() // debug endpoint
    {
        var chats = await _repo.GetAllAsync();
        var chatResponseModels = chats.Select(s => s.ToChatResponseModel());

        return Ok(chatResponseModels);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var chat = await _repo.GetByIdAsync(id);
        if (chat == null) return NotFound();
        return Ok(chat.ToChatResponseModel());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] ChatRequestModel chatRequest)
    {
        var chat = await _repo.CreateAsync(chatRequest);
        return Ok(chat.ToChatResponseModel());
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, [FromBody] ChatUpdateModel chatUpdate)
    {
        var chat = await _repo.UpdateAsync(id, chatUpdate);
        if (chat == null) return NotFound();
        return Ok(chat.ToChatResponseModel());
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var chat = await _repo.DeleteAsync(id);
        if (chat == null) return NotFound();
        return Ok($"Chat \"{chat.Name}\" deleted");
    }
}