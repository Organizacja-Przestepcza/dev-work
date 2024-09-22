using api.Data;
using api.Dtos.Bookmark;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class BookmarkRepository : IBookmarkRepository
{
    private readonly AppDbContext _context;

    public BookmarkRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Bookmark>> GetAllAsync()
    {
        return await _context.Bookmarks.ToListAsync();
    }

    public async Task<Bookmark?> GetByIdAsync(string id)
    {
        return await _context.Bookmarks.FindAsync(id);
    }

    public async Task<Bookmark> CreateAsync(BookmarkRequestModel bookmarkRequest)
    {
        var bookmark = bookmarkRequest.ToBookmark();
        bookmark.Id = Guid.NewGuid().ToString();
        await _context.Bookmarks.AddAsync(bookmark);
        await _context.SaveChangesAsync();
        return bookmark;
    }

    public async Task<Bookmark?> DeleteAsync(string id)
    {
        var bookmark = await _context.Bookmarks.FindAsync(id);
        if (bookmark == null) return null;
        _context.Bookmarks.Remove(bookmark);
        await _context.SaveChangesAsync();
        return bookmark;
    }
}