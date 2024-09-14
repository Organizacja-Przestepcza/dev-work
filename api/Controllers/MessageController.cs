using api.Data;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/messages")]
[ApiController]
public class MessageController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;
    [HttpGet]
    public async Task<IActionResult> GetAll() // debug endpoint
    {
        var messages = await _context.Messages.ToListAsync();
        var messageResponseModels = messages.Select(s => s.ToMessageResponseModel());
        
        return Ok(messageResponseModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var message = await _context.Messages.FindAsync(id);
        if (message == null)
        {
            return NotFound();
        }
        return Ok(message.ToMessageResponseModel());
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Message message)
    {
       
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Message message)
    {
       
        return Ok();
    }
}