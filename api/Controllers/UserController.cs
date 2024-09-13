using api.Data;
using api.Dtos.User;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers;
[Route("api/users")]
[ApiController]
public class UserController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _context.Users.ToList()
            .Select(s => s.ToUserResponseModel());
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
        return Ok(user.ToUserResponseModel());
    }
    
    [HttpPost]
    public IActionResult Add([FromBody] UserRequestModel userRequestModel)
    {
        var user = userRequestModel.ToUser();
       
        _context.Users.Add(user);
        _context.SaveChanges();
        
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] AppUser appUser)
    {
       
        return Ok();
    }
}