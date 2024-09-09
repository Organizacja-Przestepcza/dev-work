using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/chats")]
[ApiController]
public class ChatController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;
    [HttpGet]
    public IActionResult GetAll()
    {
        var chats = _context.Chats.ToList();
        
        return Ok(chats);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var chat = _context.Chats.Find(id);
        if (chat == null)
        {
            return NotFound();
        }
        return Ok(chat);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Chat chat)
    {
       
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] Chat chat)
    {
       
        return Ok();
    }
}