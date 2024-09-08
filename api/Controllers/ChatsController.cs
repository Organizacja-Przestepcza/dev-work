using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/chats")]
public class ChatsController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public  ActionResult<IEnumerable<Chat>> GetChats()
    {
      
        return Ok();
    }

    [HttpPost]
    public ActionResult<Chat> AddChat([FromBody] Chat chat)
    {
       
        return Ok();
    }
    
    [HttpPut]
    public ActionResult<Chat> UpdateChat([FromBody] Chat chat)
    {
       
        return Ok();
    }
}