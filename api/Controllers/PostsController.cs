using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/posts")]
[ApiController]
public class PostsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var posts = _context.Posts.ToList();
        
        return Ok(posts);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var post = _context.Posts.Find(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
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