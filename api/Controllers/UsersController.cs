using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/users")]
[ApiController]
public class UsersController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _context.Users.ToList();
        
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
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