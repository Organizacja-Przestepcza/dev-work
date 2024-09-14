using api.Dtos.Post;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IPostRepository
{
    Task<IActionResult> GetAll();
    Task<IActionResult> GetById(string id);
    Task<IActionResult> Add(PostRequestModel postRequest);
    Task<IActionResult> Update(Post post);
    Task<IActionResult> Delete(string id);
}