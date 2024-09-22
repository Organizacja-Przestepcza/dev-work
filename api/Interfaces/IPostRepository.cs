using api.Dtos.Post;
using api.Models;

namespace api.Interfaces;

public interface IPostRepository
{
    Task<List<Post>> GetAllAsync();
    Task<Post?> GetByIdAsync(string id);
    Task<Post> CreateAsync(PostRequestModel postRequest, string userId);
    Task<Post?> UpdateAsync(string id, PostUpdateModel postUpdate);
    Task<Post?> DeleteAsync(string id);
}