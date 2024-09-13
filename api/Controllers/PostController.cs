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
    public IActionResult GetAll()
    {
        var posts = _context.Posts.ToList()
            .Select(s => s.ToPostResponseModel());
        
        return Ok(posts);
    }
    [Authorize]
    [HttpGet("{id}")]
 
    public IActionResult GetById([FromRoute] string id)
    {
        var post = _context.Posts.Find(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post.ToPostResponseModel());
    }

    [HttpPost]
  
    public IActionResult Add([FromBody] Post post)
    {
       
        return Ok();
    }

    [HttpPut]
    public IActionResult Update([FromBody] Post post)
    {
        return Ok();
    }
}