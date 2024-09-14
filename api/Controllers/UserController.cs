using api.Data;
using api.Dtos.User;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers;
[Route("api/users")]
[ApiController]
public class UserController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;
    [HttpGet]
    public async Task<IActionResult> GetAll() // debug
    {
        var users = await _context.Users.ToListAsync();
        var userResponseModels = users.Select(s => s.ToUserResponseModel());
        return Ok(userResponseModels);
        
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user.ToUserResponseModel());
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AppUser appUser)
    {
       
        return Ok();
    }
}