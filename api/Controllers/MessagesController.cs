using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/messages")]
public class MessagesController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
      
        return Ok();
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