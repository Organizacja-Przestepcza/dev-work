using api.Dtos.AppUser;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers;
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repo;

    public UserController(IUserRepository repo)
    {
        _repo = repo;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll() // debug
    {
        var users = await _repo.GetAllAsync();
        var userResponseModels = users.Select(s => s.ToUserResponseModel());
        return Ok(userResponseModels);
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user.ToUserResponseModel());
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UserUpdateModel userUpdate)
    {
        var user = await _repo.UpdateAsync(id, userUpdate);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user.ToUserResponseModel());
    }

}