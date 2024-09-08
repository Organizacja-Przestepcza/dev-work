using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/messages")]
public class MessagesController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public  ActionResult<IEnumerable<Message>> GetMessages()
    {
      
        return Ok();
    }

    [HttpPost]
    public ActionResult<Message> AddMessage([FromBody] Message message)
    {
       
        return Ok();
    }
    
    [HttpPut]
    public ActionResult<Message> UpdateMessage([FromBody] Message message)
    {
       
        return Ok();
    }
}