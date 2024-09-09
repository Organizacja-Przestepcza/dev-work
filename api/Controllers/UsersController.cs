using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/users")]
public class UsersController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
      
        return Ok();
    }

    [HttpPost]
    public IActionResult Add([FromBody] User user)
    {
       
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] User user)
    {
       
        return Ok();
    }
}