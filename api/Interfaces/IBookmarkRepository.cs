using api.Dtos.Bookmark;
using api.Dtos.Post;
using api.Models;

namespace api.Interfaces;

public interface IBookmarkRepository
{
    Task<List<Bookmark>> GetAllAsync(string userId);

    Task<Bookmark?> GetByIdAsync(string userId, string postId);
    Task<List<Bookmark>> GetForListAsync(List<string> postIds, string userId);

    Task<Bookmark?> CreateAsync(string userId, string postId);

    Task<Bookmark?> DeleteAsync(string userId, string postId);
}