using api.Data;
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
    public IActionResult GetAll()
    {
        var messages = _context.Messages.ToList();
        
        return Ok(messages);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var message = _context.Messages.Find(id);
        if (message == null)
        {
            return NotFound();
        }
        return Ok(message);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Message message)
    {
       
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] Message message)
    {
       
        return Ok();
    }
}