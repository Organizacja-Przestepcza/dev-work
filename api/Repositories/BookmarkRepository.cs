using api.Data;
using api.Dtos.Bookmark;
using api.Dtos.Post;
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

    public async Task<List<Bookmark>> GetAllAsync(string userId)
    {
        return await _context.Bookmarks.Include(b => b.Post).Where(b => b.UserId == userId).ToListAsync();
    }

    public async Task<Bookmark?> GetByIdAsync(string userId, string postId)
    {
        return await _context.Bookmarks.Include(b => b.Post)
            .FirstOrDefaultAsync(b => b.UserId == userId && b.PostId == postId);
    }

    public async Task<List<Bookmark>> GetForListAsync(List<string> postIds, string userId)
    {
        if (postIds.Count == 0)
        {
            return [];
        }

        return await _context.Bookmarks
            .Where(b => postIds.Contains(b.PostId) && b.UserId == userId)
            .ToListAsync();
    }

    public async Task<Bookmark?> CreateAsync(string userId, string postId)
    {
        var bookmark = await GetByIdAsync(userId, postId);
        if (bookmark != null) return null;
        bookmark = new Bookmark
        {
            UserId = userId,
            PostId = postId,
            CreatedAt = DateTime.Now
        };
        await _context.Bookmarks.AddAsync(bookmark);
        await _context.SaveChangesAsync();
        return bookmark;
    }

    public async Task<Bookmark?> DeleteAsync(string userId, string postId)
    {
        var bookmark = await GetByIdAsync(userId, postId);
        if (bookmark == null) return null;
        _context.Bookmarks.Remove(bookmark);
        await _context.SaveChangesAsync();
        return bookmark;
    }
}