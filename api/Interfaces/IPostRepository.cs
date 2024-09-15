using api.Dtos.Post;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IPostRepository
{
    Task<List<Post>> GetAll();
    Task<Post?> GetById(string id);
    Task<Post> Add(PostRequestModel postRequest);
    Task<Post?> Update(Post post);
    Task<Post?> Delete(string id);
}