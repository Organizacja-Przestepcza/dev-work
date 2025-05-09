using api.Dtos.Post;
using api.Helpers;
using api.Models;

namespace api.Interfaces;

public interface IPostRepository
{
    Task<List<PostResponseModel>> GetAllOffsetAsync(PaginationQuery query);
    Task<List<PostResponseModel>> GetCommentsOffsetAsync(string id, PaginationQuery query);
    Task<PostResponseModel?> GetResponseModelByIdAsync(string id);
    Task<Post?> GetByIdAsync(string id);
    Task<Post> CreateAsync(PostRequestModel postRequest, string userId);
    Task<Post?> UpdateAsync(string id, PostUpdateModel postUpdate);
    Task<Post?> DeleteAsync(string id);
}