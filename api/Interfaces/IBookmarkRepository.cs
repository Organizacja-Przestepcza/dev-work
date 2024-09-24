using api.Dtos.Bookmark;
using api.Models;

namespace api.Interfaces;

public interface IBookmarkRepository
{
    Task<List<Bookmark>> GetAllAsync(string userId);

    Task<Bookmark?> GetByIdAsync(string userId, string postId);

    Task<Bookmark?> CreateAsync(string userId, string postId);

    Task<Bookmark?> DeleteAsync(string userId, string postId);
}