using api.Dtos.Message;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[Route("api/message")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageRepository _repo;

    public MessageController(IMessageRepository repo)
    {
        _repo = repo;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll() // debug endpoint
    {
        var messages = await _repo.GetAllAsync();
        var messageResponseModels = messages.Select(s => s.ToMessageResponseModel());
        
        return Ok(messageResponseModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var message = await _repo.GetByIdAsync(id);
        if (message == null)
        {
            return NotFound();
        }
        return Ok(message.ToMessageResponseModel());
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] MessageRequestModel messageRequest)
    {
        var message = await _repo.CreateAsync(messageRequest);
        return Ok(message.ToMessageResponseModel());
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] MessageUpdateModel messageUpdate, string id)
    {
         var message = await _repo.UpdateAsync(id, messageUpdate);
         if (message == null)
         {
             return NotFound();
         }
         return Ok(message.ToMessageResponseModel());
    }
}