using api.Data;
using api.Dtos.Bookmark;
using api.Models;

namespace api.Interfaces;

public interface IBookmarkRepository
{
    Task<List<Bookmark>> GetAllAsync(string userId);

    Task<Bookmark?> GetByIdAsync(string id);

    Task<Bookmark> CreateAsync(string userId, BookmarkRequestModel chat);

    Task<Bookmark?> DeleteAsync(string id);
}