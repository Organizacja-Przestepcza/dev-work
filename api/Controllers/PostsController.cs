using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/posts")]
public class PostsController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public  ActionResult<IEnumerable<Post>> GetPosts()
    {
      
        return Ok();
    }

    [HttpPost]
    public ActionResult<Post> AddPost([FromBody] Post post)
    {
       
        return Ok();
    }

    [HttpPut]
    public ActionResult<Post> UpdatePost([FromBody] Post post)
    {
        return Ok();
    }
}