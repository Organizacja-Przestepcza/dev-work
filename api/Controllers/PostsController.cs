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
    public ActionResult<IEnumerable<Post>> AddPost([FromBody] Post postDto)
    {
       
        return Ok();
    }
}