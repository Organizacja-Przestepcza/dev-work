using api.Data;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/posts")]
[ApiController]
public class PostController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;
    
    [HttpGet]
    public async Task<IActionResult> GetAll() // debug endpoint
    {
        var posts = _context.Posts.ToList()
            .Select(s => s.ToPostResponseModel());
        
        return Ok(posts);
    }
    
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var post = _context.Posts.Find(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post.ToPostResponseModel());
    }

    [HttpPost]
  
    public async Task<IActionResult> Add([FromBody] Post post)
    {
       
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Post post)
    {
        return Ok();
    }
}