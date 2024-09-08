using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/users")]
public class UsersController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public  ActionResult<IEnumerable<User>> GetUsers()
    {
      
        return Ok();
    }

    [HttpPost]
    public ActionResult<User> AddUser([FromBody] User user)
    {
       
        return Ok();
    }
    
    [HttpPut]
    public ActionResult<User> UpdateUser([FromBody] User user)
    {
       
        return Ok();
    }
}