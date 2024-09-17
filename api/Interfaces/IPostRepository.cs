using api.Dtos.Post;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IPostRepository
{
    Task<List<Post>> GetAllAsync();
    Task<Post?> GetByIdAsync(string id);
    Task<Post> CreateAsync(PostRequestModel postRequest);
    Task<Post?> UpdateAsync(string id, PostUpdateModel postUpdate);
    Task<Post?> DeleteAsync(string id);
}