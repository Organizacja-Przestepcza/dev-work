using api.Data;
using api.Dtos.Bookmark;
using api.Models;

namespace api.Interfaces;

public interface IBookmarkRepository
{
    Task<List<Bookmark>> GetAllAsync();

    Task<Bookmark?> GetByIdAsync(string id);

    Task<Bookmark> CreateAsync(BookmarkRequestModel chat);

    Task<Bookmark?> DeleteAsync(string id);
}