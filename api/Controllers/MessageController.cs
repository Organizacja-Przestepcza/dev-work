using api.Data;
using api.Dtos.Message;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/message")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageRepository _repo;
    private readonly IChatRepository _chatRepo;
    private readonly IUserRepository _userRepo;

    public MessageController(IMessageRepository repo, IChatRepository chatRepo, IUserRepository userRepo)
    {
        _repo = repo;
        _chatRepo = chatRepo;
        _userRepo = userRepo;
    }

    [HttpGet]
    [Authorize /*(Policy = IdentityData.RequireAdminPolicyName)*/]
    public async Task<IActionResult> GetAll() // debug endpoint
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var messages = await _repo.GetAllAsync();
        var messageResponseModels = messages.Select(s => s.ToMessageResponseModel());

        return Ok(messageResponseModels);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var message = await _repo.GetByIdAsync(id);
        if (message == null) return NotFound();
        return Ok(message.ToMessageResponseModel());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] MessageRequestModel messageRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var user = await _userRepo.GetByIdAsync(messageRequest.SenderId);
        if (user == null) return BadRequest($"User {messageRequest.SenderId} doesn't exist");
        var chat = await _chatRepo.GetByIdAsync(messageRequest.ReceiverId);
        if (chat == null) return BadRequest($"Chat {messageRequest.ReceiverId} doesn't exist");
        var message = await _repo.CreateAsync(messageRequest);
        return Ok($"Message {message.Id} created successfully");
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] MessageUpdateModel messageUpdate, string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var message = await _repo.UpdateAsync(id, messageUpdate);
        if (message == null) return NotFound();
        return Ok($"Message {id} updated successfully");
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var message = await _repo.DeleteAsync(id);
        return Ok($"Message {id} deleted successfully");
    }
}