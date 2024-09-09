using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;
[Route("api/posts")]
public class PostsController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
      
        return Ok();
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