using api.Data;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/chats")]
[ApiController]
public class ChatController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll() // debug endpoint
    {
        var chats = await _context.Chats.ToListAsync();
        var chatResponseModels = chats.Select(s => s.ToChatResponseModel());
        
        return Ok(chatResponseModels);
    }
    
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var chat = await _context.Chats.FindAsync(id);
        if (chat == null)
        {
            return NotFound();
        }
        return Ok(chat.ToChatResponseModel());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] Chat chat)
    {
       
        return Ok();
    }
    
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] Chat chat)
    {
       
        return Ok();
    }
}