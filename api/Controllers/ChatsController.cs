using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/chats")]
public class ChatsController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
      
        return Ok();
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