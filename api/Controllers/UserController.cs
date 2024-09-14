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
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserRequestModel userRequestModel)
    {
        var user = userRequestModel.ToUser();
       
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AppUser appUser)
    {
       
        return Ok();
    }
}